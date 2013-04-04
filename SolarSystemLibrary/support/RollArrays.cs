// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemLibrary - RollArrays.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 9:46 AM, 01/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

#endregion

namespace SolarSystemLibrary {
    ///=================================================================================================
    /// <summary>   Roll arrays. </summary>
    ///
    /// <remarks>   Cdo, 4/1/2013. </remarks>
    ///=================================================================================================
    public static class RollArrays {
        #region Fields and Constants

        /// <summary>   Category the star belongs to. </summary>
        public static readonly RollArrayItem[] StarCategory = new[]
                                                                  {
                                                                      new RollArrayItem( 0, 1, 1, "Dwarf/Hypergiant" ),
                                                                      new RollArrayItem(
                                                                          1, 2, 2, "Non Sequence Main Star" ),
                                                                      new RollArrayItem( 3, 75, 3, "Red" ),
                                                                      new RollArrayItem( 76, 89, 4, "Orange" ),
                                                                      new RollArrayItem( 90, 96, 5, "Yellow" ),
                                                                      new RollArrayItem( 97, 99, 6, "White" ),
                                                                      new RollArrayItem( 100, 100, 7, "Blue-White" )
                                                                  };

        /// <summary>   The non sequence star. </summary>
        public static readonly RollArrayItem[] NonSequenceStar = new[]
                                                                     {
                                                                         new RollArrayItem( 1, 1, 1, "Red" ),
                                                                         new RollArrayItem( 2, 2, 1, "Orange" ),
                                                                         new RollArrayItem( 3, 3, 3, "Yellow" ),
                                                                         new RollArrayItem( 4, 4, 4, "White" ),
                                                                         new RollArrayItem( 5, 5, 5, "Blue-White" ),
                                                                         new RollArrayItem( 6, 6, 6, "Blue" )
                                                                     };

        #endregion
    }
}
