namespace Package.Core.Domain.Users
{
    public enum PermissionAccess
	{
		#region Admin User and permission

		Admin_Role_Manage = 1010,
		View_Parent_Menu = 1015,
		Admin_Oprator_Manage = 1020,

		#endregion

		#region Role_Permission
		View_Role_Delete = 1100,
		View_Role_Create,
		View_Role_Edit,
		View_Role_List,
		#endregion

		#region User_Permission
		View_User_Delete = 1200,
		View_User_Create,
		View_User_Edit,
		View_User_List,
		#endregion

		#region currencyrate_Permission
		View_currencyrate_Delete = 1300,
		View_currencyrate_Create,
		View_currencyrate_Edit,
		View_currencyrate_Index,
		View_Operator_DisplayCurrencyRate,
		View_Operator_DisplayComissionPercentage,
		View_Operator_DisplayBookedPrice,

		#endregion

		#region Localize_Permission
		View_Localize_Delete = 1400,
		View_Localize_Create,
		View_Localize_Edit,
		View_Localize_Index,
		#endregion

		#region agency_Permission
		View_agency_Delete = 1500,
		View_agency_Create,
		View_agency_Edit,
		View_agency_List,
		#endregion

		#region Booking Permission
		View_Hotel_GetXml = 1600,
		View_Hotel_Search = 1601,
		View_Hotel_RemoveOrder = 1602,
		#endregion

		#region Hotel Permission
		View_Hotel_BookingSearchByEmail = 5000,
		View_Hotel_BookingSearchByName = 5001,
		#endregion

		#region Service_Hotel
		Service_Hotel_BookingWithoutPayment = 6000,
		Service_Hotel_BookingArchive_GetExcel = 6001,

		#endregion
		#region Setting_Hotel
		View_Passengers_ReqisterOrderForAnotherUser = 7000,
		#endregion

	}
}
