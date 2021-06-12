// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - DiceRoller.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 9:13 AM, 26/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System;
using System.Threading;

#endregion

namespace SolarSystemLibrary {
    ///=================================================================================================
    /// <summary>   Dice roller. </summary>
    ///
    /// <remarks>   Cdo, 3/20/2013. </remarks>
    ///=================================================================================================
    public class DiceRoller {
        /// <summary>   The random. </summary>
        private readonly ThreadLocal<Random> _random;

        #region Constructors

        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///=================================================================================================
        public DiceRoller( ) {
            this._random = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
        }

        ///=================================================================================================
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <param name="seed"> The seed. </param>
        ///=================================================================================================
        public DiceRoller( int seed ) {
            this._random = new ThreadLocal<Random>(() => new Random(seed));
        }

        #endregion

        #region Members

        ///=================================================================================================
        /// <summary>   Rolls. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <param name="numDie">   Number of dies. </param>
        /// <param name="numSides"> Number of sides. </param>
        /// <param name="modifier"> The modifier. </param>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int Roll( int numDie, int numSides, int modifier ) {
            var total = 0;

            for ( var i = 0; i < numDie; i++ ) {
                total += ( this._random.Value.Next( numSides ) + 1 ) + modifier;
            }

            return total;
        }

        ///=================================================================================================
        /// <summary>   Rolls. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <param name="numDie">   Number of dies. </param>
        /// <param name="numSides"> Number of sides. </param>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int Roll( int numDie, int numSides ) {
            return this.Roll( numDie, numSides, 0 );
        }

        ///=================================================================================================
        /// <summary>   Rolls. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <param name="numSides"> Number of sides. </param>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int Roll( int numSides ) {
            return this.Roll( 1, numSides, 0 );
        }

        ///=================================================================================================
        /// <summary>   Roll arr. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <param name="numDie">   Number of dies. </param>
        /// <param name="numSides"> Number of sides. </param>
        /// <param name="modifier"> The modifier. </param>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int[] RollArr( int numDie, int numSides, int modifier ) {
            var result = new int[numDie];

            for ( var i = 0; i < numDie; i++ ) {
                result[ i ] = ( this._random.Value.Next( numSides ) + 1 ) + modifier;
            }

            return result;
        }

        ///=================================================================================================
        /// <summary>   Gets the d 2. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int d2( ) {
            return this.Roll( 1, 2, 0 );
        }

        ///=================================================================================================
        /// <summary>   Gets the d 3. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int d3( ) {
            return this.Roll( 1, 3, 0 );
        }

        ///=================================================================================================
        /// <summary>   Gets the d 4. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int d4( ) {
            return this.Roll( 1, 4, 0 );
        }

        ///=================================================================================================
        /// <summary>   Gets the d 6. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int d6( ) {
            return this.Roll( 1, 6, 0 );
        }

        ///=================================================================================================
        /// <summary>   Gets the d 8. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int d8( ) {
            return this.Roll( 1, 8, 0 );
        }

        ///=================================================================================================
        /// <summary>   Gets the 10. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int d10( ) {
            return this.Roll( 1, 10, 0 );
        }

        ///=================================================================================================
        /// <summary>   Gets the 12. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int d12( ) {
            return this.Roll( 1, 12, 0 );
        }

        ///=================================================================================================
        /// <summary>   Gets the 20. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int d20( ) {
            return this.Roll( 1, 20, 0 );
        }

        ///=================================================================================================
        /// <summary>   Gets the 100. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int d100( ) {
            return this.Roll( 1, 100, 0 );
        }

        ///=================================================================================================
        /// <summary>   Gets the 1000. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        public int d1000( ) {
            return this.Roll( 1, 1000, 0 );
        }

        #endregion
    }
}
