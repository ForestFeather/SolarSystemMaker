// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - AtmosphericPressure.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 2:17 PM, 27/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

using System.ComponentModel;

namespace SolarSystemLibrary {
    ///=================================================================================================
    /// <summary>   Values that represent AtmosphericPressure. </summary>
    ///
    /// <remarks>   Cdo, 3/27/2013. </remarks>
    ///=================================================================================================
    public enum AtmosphericPressure {
        /// <summary>   . </summary>
        [Description("Vacuum")]
        Vacuum = -4,

        /// <summary>   . </summary>
        [Description("Trace Gasses")]
        Trace,

        /// <summary>   . </summary>
        [Description("Upper Atmosphere")] 
        AircraftAltitudes,

        /// <summary>   . </summary>
        [Description("Mount Everest Peak")] 
        Everest,

        /// <summary>   . </summary>
        [Description("Earth Standard")] 
        Standard,

        /// <summary>   . </summary>
        [Description("Dense Atmosphere")] 
        Compression,

        /// <summary>   . </summary>
        [Description("Mid-Sea")] 
        Sea,

        /// <summary>   . </summary>
        [Description("Sea Floor")] 
        SeaFloor,

        /// <summary>   . </summary>
        [Description("Marianas Trench")] 
        MarianaTrench,

        /// <summary>   . </summary>
        [Description("Earth's Mantle")] 
        EarthMantle,

        /// <summary>   . </summary>
        [Description("Jovian Surface")] 
        JupiterSurface,

        /// <summary>   . </summary>
        [Description("Earth's Core")] 
        EarthCore,

        /// <summary>   . </summary>
        [Description("Jovian Planet Core")] 
        JupiterCore,

        /// <summary>   . </summary>
        [Description("Surface of the Sun")] 
        SunSurface,

        /// <summary>   . </summary>
        [Description("Black Hole")] 
        BlackHole
    }
}
