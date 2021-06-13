// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - StarCategory.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 10:48 AM, 28/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

using System.ComponentModel;

namespace SolarSystemLibrary {
    ///=================================================================================================
    /// <summary>   Values that represent StarCategory. </summary>
    ///
    /// <remarks>   Cdo, 3/27/2013. </remarks>
    ///=================================================================================================
    public enum StarCategory {
        /// <summary>   . </summary>
        [Description("Red")]
        Red = 1,

        /// <summary>   . </summary>
        [Description("Orange")] 
        Orange,

        /// <summary>   . </summary>
        [Description("Yellow")] 
        Yellow,

        /// <summary>   . </summary>
        [Description("White")]
        White,

        /// <summary>   . </summary>
        [Description("Blue-White")] 
        BlueWhite,

        /// <summary>   . </summary>
        [Description("Blue")] 
        Blue,

        /// <summary>   . </summary>
        [Description("Dwarf")] 
        Dwarf,

        /// <summary>   . </summary>
        [Description("Hypergiant")] 
        Hypergiant,

        /// <summary>   . </summary>
        [Description("Null")] 
        NullCategory
    }
}
