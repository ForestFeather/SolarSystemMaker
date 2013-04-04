// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemLibrary - RollArrayFinder.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 9:43 AM, 01/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System.Collections.Generic;
using System.Linq;

#endregion

namespace SolarSystemLibrary {
    ///=================================================================================================
    /// <summary>   Roll array finder. </summary>
    ///
    /// <remarks>   Cdo, 3/20/2013. </remarks>
    ///=================================================================================================
    public static class RollArrayFinder {
        #region Members

        ///=================================================================================================
        /// <summary>
        ///    An IEnumerable&lt;RollArrayItem&gt; extension method that searches for the first roll.
        /// </summary>
        ///
        /// <remarks>  Cdo, 3/20/2013. </remarks>
        ///
        /// <param name="arrayItems">  The arrayItems to act on. </param>
        /// <param name="roll">        The roll. </param>
        ///
        /// <returns>  The found roll. </returns>
        ///=================================================================================================
        public static RollArrayItem FindRoll( this IEnumerable<RollArrayItem> arrayItems, int roll ) {
            return arrayItems.FirstOrDefault( item => roll <= item.UpperBound && item.LowerBound <= roll );
        }

        #endregion
    }
}
