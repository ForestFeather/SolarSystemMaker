// // ==========================================================================================================
// // 
// //  File ID: SolarSystemMaker - SolarSystemMaker - MainWindow.xaml.cs 
// // 
// //  Last Changed By: ForestFeather - 
// //  Last Changed Date: 8:31 PM, 23/03/2016
// //  Created Date: 5:54 PM, 11/02/2015
// // 
// //  Notes:
// //  
// // ==========================================================================================================

#region Imported Namespaces

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using SolarSystemLibrary;
using SolarSystemLibrary.Generators;
using SolarSystemLibrary.Models;

using SolarSystemMaker.ViewModels;

#endregion

namespace SolarSystemMaker.Views {
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Interaction logic for MainWindow.xaml. </summary>
    ///
    /// <remarks>   Cdo, 3/29/2013. </remarks>
    ///
    /// <seealso cref="System.Windows.Window"/>
    ///-------------------------------------------------------------------------------------------------
    public partial class MainWindow : Window {

        /// <summary>   The generator. </summary>
        private readonly ISystemGenerator _generator;

        /// <summary>   The system. </summary>
        private ISolarSystem _system;

        private bool _generatingSystem = false;

        #region Constructors

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///-------------------------------------------------------------------------------------------------
        public MainWindow() {
            this.InitializeComponent();

            var simpleSolarGenerator = new SimpleSolarGenerator();
            var simplePlanetGenerator = new SimplePlanetGenerator();
            var simpleLunarGenerator = new SimpleLunarGenerator();
            this._generator = new SimpleSolarSystemGenerator(
                simpleSolarGenerator,
                simplePlanetGenerator,
                simpleLunarGenerator);

            // Init them all
            simpleLunarGenerator.Initialize();
            simplePlanetGenerator.Initialize();
            simpleSolarGenerator.Initialize();
            this._generator.Initialize();

            // set the main viewmodel
            this.MainViewModel = new MainViewModel();
            this.DataContext = this.MainViewModel;
            this.NumSystemsGenerated.Text = "0";
        }

        #endregion

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the main view model. </summary>
        ///
        /// <value> The main view model. </value>
        ///-------------------------------------------------------------------------------------------------
        private MainViewModel MainViewModel { get; set; }

        #region Members

        private async void OnClear(object sender, RoutedEventArgs e)
        {
            this.NumSystemsGenerated.Text = "0";

            // Clear out old viewmodels
            this.MainViewModel.ViewModels.Clear();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Raises the routed event. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ///-------------------------------------------------------------------------------------------------
        private async void OnClickGenerate(object sender, RoutedEventArgs e) {
            if(_generatingSystem) { MessageBox.Show("Already generating system!"); } else { _generatingSystem = true; }
            
            // Check current variables 
            this.NumSystemsGenerated.Text = "0";

            // Clear out old viewmodels
            this.MainViewModel.ViewModels.Clear();

            var systemCount = await this.TryFindStarSystem(new Progress<int>(numSystemsGenerated => NumSystemsGenerated.Text = numSystemsGenerated.ToString()));

            if (systemCount > 0)
            {
                foreach (var star in this._system.Stars)
                {
                    this.MainViewModel.ViewModels.Add(new StarViewModel { DomainObject = star });
                }

                foreach (var planet in this._system.Planets)
                {
                    this.MainViewModel.ViewModels.Add(new PlanetViewModel { DomainObject = planet });
                    foreach (var lunarBody in planet.LunarBodies)
                    {
                        this.MainViewModel.ViewModels.Add(new LunarBodyViewModel { DomainObject = lunarBody });
                    }
                }
            }
        }

        private async Task<int> TryFindStarSystem(IProgress<int> progress) {
            int numStars = string.IsNullOrEmpty(this.NumberOfStars.Text) ||
               !Int32.TryParse(this.NumberOfStars.Text, out numStars) || numStars <= 0
                   ? -1
                   : numStars;
            bool mainSequence = this.MainSequenceStar.IsChecked == true;
            bool habitableStar = this.HabitableStar.IsChecked == true;
            //StarColor starColor = 
            int numPlanets = string.IsNullOrEmpty(this.NumberOfStars.Text) ||
                             !Int32.TryParse(this.NumberOfStars.Text, out numPlanets) || numPlanets <= 0
                                 ? -1
                                 : numPlanets;
            int numHabitablePlanets = string.IsNullOrEmpty(this.NumHabitablePlanets.Text) ||
                                      !Int32.TryParse(this.NumHabitablePlanets.Text, out numHabitablePlanets) ||
                                      numHabitablePlanets <= 0
                                          ? -1
                                          : numHabitablePlanets;
            int numGoldilocksPlanets = string.IsNullOrEmpty(this.NumGoldilocksPlanets.Text) ||
                                       !Int32.TryParse(this.NumGoldilocksPlanets.Text, out numGoldilocksPlanets) ||
                                       numGoldilocksPlanets <= 0
                                           ? -1
                                           : numGoldilocksPlanets;

            bool valid;
            var systemCount = 0;
            var counter = 0;
            var maxGenNum = 10000000;
            do {
                valid = true;
                this._system =
                    await this.GenerateSolarSystem(numStars, numPlanets, numHabitablePlanets, numGoldilocksPlanets);
                 
                if (_system != null) { 
                    if (mainSequence && !this._system.Stars.Any(s => s.MainSequenceStar)) {
                        valid = false;
                    }
                    if (habitableStar && this._system.NumHabitableBodies == 0) {
                        valid = false;
                    }

                    if (numHabitablePlanets > _system.NumHabitableBodies) {
                        valid = false;
                    }
                } else { valid = false; }

                progress.Report(++systemCount);                
            } while (!valid && counter++ <= maxGenNum);

            if (counter >= maxGenNum)
            {
                MessageBox.Show(string.Format("Generated over {0} star systems without meeting requirements.  Aborting.", maxGenNum));
                systemCount = 0;
            }

            _generatingSystem = false;

            return systemCount;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Generates a solar system. </summary>
        ///
        /// <remarks>   Forest Feather, 3/23/2016. </remarks>
        ///
        /// <param name="numStars">             Number of stars. </param>
        /// <param name="numPlanets">           Number of planets. </param>
        /// <param name="numHabitablePlanets">  Number of habitable planets. </param>
        /// <param name="numGoldilocksPlanets"> Number of goldilocks planets. </param>
        ///
        /// <returns>   The solar system. </returns>
        ///-------------------------------------------------------------------------------------------------
        protected virtual async Task<ISolarSystem> GenerateSolarSystem( int numStars,
                                                                        int numPlanets,
                                                                        int numHabitablePlanets,
                                                                        int numGoldilocksPlanets ) {
            return await Task.Run(() => this._generator.GenerateSolarSystem(
                numStars: numStars,
                numPlanets: numPlanets,
                numHabitablePlanets: numHabitablePlanets,
                numGoldilocksZonePlanets: numGoldilocksPlanets,
                maxNumToGenerate: 1));
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Raises the routed event. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ///-------------------------------------------------------------------------------------------------
        private void OnCopyToClipboard( object sender, RoutedEventArgs e ) {
            Clipboard.SetText( this._system.ToString( ) );
        }

        #endregion
    }
}
