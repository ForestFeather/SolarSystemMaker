// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemLibrary - Star.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 10:21 AM, 16/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

namespace SolarSystemLibrary.Models {
    ///=================================================================================================
    /// <summary>   Star. </summary>
    ///
    /// <remarks>   Cdo, 3/28/2013. </remarks>
    ///
    /// <seealso cref="SolarSystemLibrary.Models.IStar"/>
    /// <seealso cref="IStar"/>
    ///=================================================================================================
    public class Star : IStar {
        #region Constructors

        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 4/16/2013. </remarks>
        ///=================================================================================================
        public Star( ) {
            this.Category = StarCategory.NullCategory;
            this.MainSequenceStar = true;
            this.SolarMass = 0.0;
        }

        #endregion

        #region Implementation of IStar

        ///=================================================================================================
        /// <summary>   Gets or sets the category. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.Category"/>
        /// <seealso cref="IStar.Category"/>
        ///=================================================================================================
        public StarCategory Category { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets a value indicating whether the main sequence star. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.MainSequenceStar"/>
        /// <seealso cref="IStar.MainSequenceStar"/>
        ///=================================================================================================
        public bool MainSequenceStar { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the solar mass. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.SolarMass"/>
        /// <seealso cref="IStar.SolarMass"/>
        ///=================================================================================================
        public double SolarMass { get; set; }

        public IConstruct? Construct { get; set; }

        #endregion

        #region Overrides of Object

        ///=================================================================================================
        /// <summary>
        ///     Returns a <see cref="T:System.String"/> that represents the current
        ///     <see cref="T:System.Object"/>.
        /// </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="System.Object.ToString()"/>
        /// <seealso cref="object.ToString()"/>
        ///=================================================================================================
        public override string ToString( ) {
            return
                string.Format(
                    "Star Size: {0}\r\n\tSolar Mass: {1}\t\tMain Sequence Star: {2}{3}\r\n",
                    this.Category,
                    this.SolarMass,
                    this.MainSequenceStar,
                    Construct != null ? "\r\n\tConstruct: " + Construct : "");
        }

        #endregion
    }
}
