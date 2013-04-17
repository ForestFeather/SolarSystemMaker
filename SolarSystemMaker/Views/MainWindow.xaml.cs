// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - MainWindow.xaml.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 8:23 AM, 02/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System.Collections.ObjectModel;
using System.Windows;
using SolarSystemLibrary;
using SolarSystemLibrary.Generators;
using SolarSystemLibrary.Models;
using SolarSystemMaker.ViewModels;

#endregion

namespace SolarSystemMaker.Views {
    ///=================================================================================================
    /// <summary>   Interaction logic for MainWindow.xaml. </summary>
    ///
    /// <remarks>   Cdo, 3/29/2013. </remarks>
    ///
    /// <seealso cref="System.Windows.Window"/>
    ///=================================================================================================
    public partial class MainWindow : Window {
        /// <summary>   The generator. </summary>
        private readonly ISystemGenerator _generator;

        /// <summary>   The system. </summary>
        private ISolarSystem _system;

        private MainViewModel MainViewModel { get; set; }

        #region Constructors

        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///<param name="mainViewModel"> </param>
        ///<remarks>   Cdo, 3/29/2013. </remarks>
        ///=================================================================================================
        public MainWindow( ) {
            this.InitializeComponent( );

            var simpleSolarGenerator = new SimpleSolarGenerator( );
            var simplePlanetGenerator = new SimplePlanetGenerator( );
            var simpleLunarGenerator = new SimpleLunarGenerator( );
            this._generator = new SimpleSolarSystemGenerator(
                simpleSolarGenerator, simplePlanetGenerator, simpleLunarGenerator );

            // Init them all
            simpleLunarGenerator.Initialize( );
            simplePlanetGenerator.Initialize( );
            simpleSolarGenerator.Initialize( );
            this._generator.Initialize( );

            // set the main viewmodel
            MainViewModel = new MainViewModel();
            this.DataContext = MainViewModel;
        }

        #endregion



        #region Members

        ///=================================================================================================
        /// <summary>   Raises the routed event. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ///=================================================================================================
        private void OnClickGenerate( object sender, RoutedEventArgs e ) {
            // Clear out old viewmodels
            MainViewModel.ViewModels.Clear();

            this._system = this._generator.GenerateSolarSystem( );
            foreach ( var star in _system.Stars ) {
                MainViewModel.ViewModels.Add(new StarViewModel{DomainObject =  star});
            }

            foreach ( var planet in _system.Planets ) {
                MainViewModel.ViewModels.Add(new PlanetViewModel{DomainObject = planet});
                foreach ( var lunarBody in planet.LunarBodies ) {
                    MainViewModel.ViewModels.Add(new LunarBodyViewModel { DomainObject = lunarBody });
                }
            }
        }

        ///=================================================================================================
        /// <summary>   Raises the routed event. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ///=================================================================================================
        private void OnCopyToClipboard( object sender, RoutedEventArgs e ) {
            Clipboard.SetText( this._system.ToString( ) );
        }

        #endregion
    }
}
