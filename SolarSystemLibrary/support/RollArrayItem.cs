// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemLibrary - RollArrayItem.cs 
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

namespace SolarSystemLibrary {
    ///=================================================================================================
    /// <summary>   Roll array item. </summary>
    ///
    /// <remarks>   Cdo, 3/20/2013. </remarks>
    ///=================================================================================================
    public class RollArrayItem {
        #region Constructors

        ///=================================================================================================
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/20/2013. </remarks>
        ///
        /// <param name="lb">   The lower bound. </param>
        /// <param name="ub">   The upper bound. </param>
        /// <param name="id">   The identifier. </param>
        /// <param name="desc"> The description. </param>
        ///=================================================================================================
        public RollArrayItem( int lb, int ub, int id, string desc ) {
            this.LowerBound = lb;
            this.UpperBound = ub;
            this.Identifier = id;
            this.Description = desc;
        }

        #endregion

        #region Properties

        ///=================================================================================================
        /// <summary>   Gets or sets the lower bound. </summary>
        ///
        /// <value> The lower bound. </value>
        ///=================================================================================================
        public int LowerBound { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the upper bound. </summary>
        ///
        /// <value> The upper bound. </value>
        ///=================================================================================================
        public int UpperBound { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the identifier. </summary>
        ///
        /// <value> The identifier. </value>
        ///=================================================================================================
        public int Identifier { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ///=================================================================================================
        public string Description { get; set; }

        #endregion
    }
}
