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
using System.Linq;
using System.Threading;

#endregion

namespace SolarSystemLibrary {
    public sealed class DiceModifiers
    {
        private int _curveValue = 1;
        private int _curveModifier = 0;

        private DiceModifiers()
        {
            _curveValue = 1;
            _curveModifier = 0;
        }

        private static readonly Lazy<DiceModifiers> lazy = new Lazy<DiceModifiers>(() => new DiceModifiers());
        public static DiceModifiers Instance {  get { return lazy.Value; } }

        public int CurveValue {  get { return _curveValue; } }

        public int CurveModifier { get { return _curveModifier; } }

        public void SetValues(int curveValue, int curveModifier)
        {
            _curveValue = curveValue < 1 ? 1 : curveValue;
            var tempCurve = 0;
            if( _curveValue <= Math.Abs(curveModifier))
            {
                tempCurve = _curveValue - 1;
            } else { tempCurve = curveModifier; }

            _curveModifier = curveModifier < 0 ? -tempCurve : tempCurve;
        }
    }
    
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
            var modifiers = DiceModifiers.Instance;

            // Gather values for curve estimation
            int[] vals = new int[modifiers.CurveValue];
            for (int curve = 0; curve < modifiers.CurveValue; curve++)
            {
                for (var i = 0; i < numDie; i++)
                {
                    vals[curve] += (this._random.Value.Next(numSides) + 1) + modifier;
                }
            }

            // Sort
            Array.Sort(vals);

            // Remove from modifiers
            if(modifiers.CurveModifier != 0) {
                var list = vals.ToList();
                for(var i = 0; i < Math.Abs(modifiers.CurveModifier); i++)
                {
                    list.RemoveAt(modifiers.CurveModifier > 0 ? 0 : list.Count - 1);
                }

                vals = list.ToArray();
            }

            return (int)vals.Average();
        }

        public int RollUnmodified(int numDie, int numSides, int modifier)
        {
            var total = 0;

            for (var i = 0; i < numDie; i++)
            {
                total += (this._random.Value.Next(numSides) + 1) + modifier;
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
