// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - SimpleSolarGenerator.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 12:12 PM, 28/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using SolarSystemLibrary.Models;

#endregion

namespace SolarSystemLibrary.Generators {
    ///=================================================================================================
    /// <summary>   Simple solar generator. </summary>
    ///
    /// <remarks>   Cdo, 3/28/2013. </remarks>
    ///
    /// <seealso cref="ISolarGenerator"/>
    ///=================================================================================================
    public class SimpleSolarGenerator : ISolarGenerator {
        #region Constructors

        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///=================================================================================================
        public SimpleSolarGenerator( ) {
            this.Initialized = false;
        }

        #endregion

        #region Implementation of ISolarGenerator

        ///=================================================================================================
        /// <summary>   Gets or sets a value indicating whether the initialized. </summary>
        ///
        /// <seealso cref="ISolarGenerator.Initialized"/>
        ///
        /// ### <value> true if initialized, false if not. </value>
        ///=================================================================================================
        public bool Initialized { get; private set; }

        ///=================================================================================================
        /// <summary>   Initializes this object. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <seealso cref="ISolarGenerator.Initialize"/>
        ///
        /// ### <returns>   true if it succeeds, false if it fails. </returns>
        ///=================================================================================================
        public bool Initialize( ) {
            this.Dice = new DiceRoller( );
            this.Initialized = true;
            return true;
        }

        ///=================================================================================================
        /// <summary>   Generates a solar body. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.ISolarGenerator.GenerateSolarBody(optional StarCategory,optional bool?,optional ISolarSystem)"/>
        ///
        /// ### <param name="category">     (optional) the category. </param>
        /// ### <param name="mainSequence"> (optional) the main sequence. </param>
        /// ### <param name="parentSystem"> (optional) the parent system. </param>
        /// ### <returns>   The solar body. </returns>
        ///=================================================================================================
        public IStar GenerateSolarBody( StarCategory category = StarCategory.NullCategory,
                                        bool? mainSequence = new bool?( ),
                                        ISolarSystem parentSystem = null ) {
            // Don't do anything if not initialized
            if ( !this.Initialized ) {
                return null;
            }

            var star = new Star {Category = category, MainSequenceStar = ( mainSequence == true )};

            // Randomly create a star
            this.RollRandomStar( star );

            // If we roll for non-main sequence or if this is a non-main sequence, set and roll here
            if ( mainSequence == false ||
                 ( mainSequence != false && star.Category == StarCategory.NullCategory ) ) {
                this.RollNonMainSequenceStar( star );
            }

            // Determine our solar mass
            if ( star.MainSequenceStar ) {
                this.RollMainSequenceSolarMass( star );
            } else {
                this.RollNonSequenceSolarMass( star );
            }

            return star;
        }

        ///=================================================================================================
        /// <summary>   Generates a main sequence star. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.ISolarGenerator.GenerateMainSequenceStar(optional StarCategory,optional ISolarSystem)"/>
        ///
        /// ### <param name="category">     (optional) the category. </param>
        /// ### <param name="parentSystem"> (optional) the parent system. </param>
        /// ### <returns>   The main sequence star. </returns>
        ///=================================================================================================
        public IStar GenerateMainSequenceStar( StarCategory category = StarCategory.NullCategory,
                                               ISolarSystem parentSystem = null ) {
            // Don't do anything if not initialized
            if ( !this.Initialized ) {
                return null;
            }

            // Create star
            var star = new Star( );

            // Keep rolling til we get a main sequence star, this will likely only run once.
            do {
                star.Category = category;
                this.RollRandomStar( star );
            } while ( star.Category ==
                      StarCategory.NullCategory );

            // Generate a mass
            this.RollMainSequenceSolarMass( star );

            return star;
        }

        ///=================================================================================================
        /// <summary>   Generates a non main sequence star. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.ISolarGenerator.GenerateNonMainSequenceStar(optional StarCategory,optional ISolarSystem)"/>
        ///
        /// ### <param name="category">     (optional) the category. </param>
        /// ### <param name="parentSystem"> (optional) the parent system. </param>
        /// ### <returns>   The non main sequence star. </returns>
        ///=================================================================================================
        public IStar GenerateNonMainSequenceStar( StarCategory category = StarCategory.NullCategory,
                                                  ISolarSystem parentSystem = null ) {
            // Don't do anything if not initialized
            if ( !this.Initialized ) {
                return null;
            }

            // Create star
            var star = new Star {Category = category};

            // roll a non main sequence star
            this.RollNonMainSequenceStar( star );

            // Generate a mass
            this.RollNonSequenceSolarMass( star );

            return star;
        }

        ///=================================================================================================
        /// <summary>   Generates a life supporting star. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.ISolarGenerator.GenerateLifeSupportingStar(optional StarCategory,optional bool?,optional ISolarSystem)"/>
        ///
        /// ### <param name="category">     (optional) the category. </param>
        /// ### <param name="mainSequence"> (optional) the main sequence. </param>
        /// ### <param name="parentSystem"> (optional) the parent system. </param>
        /// ### <returns>   The life supporting star. </returns>
        ///=================================================================================================
        public IStar GenerateLifeSupportingStar( StarCategory category = StarCategory.NullCategory,
                                                 bool? mainSequence = new bool?( ),
                                                 ISolarSystem parentSystem = null ) {
            // Don't do anything if not initialized
            if ( !this.Initialized ) {
                return null;
            }

            // Create star
            var star = new Star( );

            // Keep rolling til we get a non main sequence star, this will likely only run once.
            do {
                star.Category = category;
                this.RollRandomStar( star );
            } while ( star.Category ==
                      StarCategory.Dwarf ||
                      star.Category == StarCategory.Hypergiant );

            // If we roll for non-main sequence or if this is a non-main sequence, set and roll here
            if ( mainSequence == false ||
                 ( mainSequence != false && star.Category == StarCategory.NullCategory ) ) {
                this.RollNonMainSequenceStar( star );
            }

            // Determine our solar mass
            if ( star.MainSequenceStar ) {
                this.RollMainSequenceSolarMass( star );
            } else {
                this.RollNonSequenceSolarMass( star );
            }

            return star;
        }

        #region Members

        ///=================================================================================================
        /// <summary>   Roll main sequence solar mass. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="star"> The star. </param>
        ///=================================================================================================
        private void RollMainSequenceSolarMass( IStar star ) {
            switch ( star.Category ) {
                case StarCategory.Dwarf:
                    star.SolarMass = this.Dice.Roll( 40 ) / 100.0;
                    break;
                case StarCategory.Hypergiant:
                    star.SolarMass = this.Dice.d1000( ) + ( this.Dice.d100( ) / 100.0 );
                    break;
                case StarCategory.Red:
                    star.SolarMass = this.Dice.Roll( 1, 35, 35 ) / 100.0;
                    break;
                case StarCategory.Orange:
                    star.SolarMass = this.Dice.Roll( 1, 40, 65 ) / 100.0;
                    break;
                case StarCategory.Yellow:
                    star.SolarMass = this.Dice.Roll( 1, 70, 95 ) / 100.0;
                    break;
                case StarCategory.White:
                    star.SolarMass = this.Dice.Roll( 1, 75, 150 ) / 100.0;
                    break;
                case StarCategory.BlueWhite:
                    star.SolarMass = this.Dice.Roll( 1, 175, 225 ) / 100.0;
                    break;
            }
        }

        ///=================================================================================================
        /// <summary>   Roll non sequence solar mass. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="star"> The star. </param>
        ///=================================================================================================
        private void RollNonSequenceSolarMass( IStar star ) {
            star.SolarMass = ( ( (int) star.Category ) * this.Dice.d10( ) ) +
                             this.Dice.Roll( ( (int) star.Category ) - 1 ) +
                             ( this.Dice.d100( ) / 100.0 );
        }

        ///=================================================================================================
        /// <summary>   Roll non main sequence star. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="star"> The star. </param>
        ///=================================================================================================
        private void RollNonMainSequenceStar( IStar star ) {
            star.MainSequenceStar = false;
            if ( star.Category !=
                 StarCategory.NullCategory ) {
                return;
            }

            var nonSequenceRoll = this.Dice.d6( );
            switch ( nonSequenceRoll ) {
                case 1:
                    star.Category = StarCategory.Red;
                    break;
                case 2:
                    star.Category = StarCategory.Orange;
                    break;
                case 3:
                    star.Category = StarCategory.Yellow;
                    break;
                case 4:
                    star.Category = StarCategory.White;
                    break;
                case 5:
                    star.Category = StarCategory.BlueWhite;
                    break;
                case 6:
                    star.Category = StarCategory.Blue;
                    break;
            }
        }

        ///=================================================================================================
        /// <summary>   Roll random star. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="star"> The star. </param>
        ///=================================================================================================
        private void RollRandomStar( IStar star ) {
            var categoryRoll =
                RollArrays.StarCategory.FindRoll( this.Dice.Roll( (int) StarCategory.NullCategory - 1 ) ).Identifier;
            star.MainSequenceStar = ( categoryRoll != 2 );

            if ( star.Category !=
                 StarCategory.NullCategory ) {
                return;
            }

            switch ( categoryRoll ) {
                case 1:
                    star.Category = this.Dice.d2( ) == 1 ? StarCategory.Dwarf : StarCategory.Hypergiant;
                    break;
                case 2:
                    break;
                case 3:
                    star.Category = StarCategory.Red;
                    break;
                case 4:
                    star.Category = StarCategory.Orange;
                    break;
                case 5:
                    star.Category = StarCategory.Yellow;
                    break;
                case 6:
                    star.Category = StarCategory.White;
                    break;
                case 7:
                    star.Category = StarCategory.BlueWhite;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #endregion

        #region Properties

        ///=================================================================================================
        /// <summary>   Gets or sets the dice. </summary>
        ///
        /// <value> The dice. </value>
        ///=================================================================================================
        protected DiceRoller Dice { get; set; }

        #endregion
    }
}
