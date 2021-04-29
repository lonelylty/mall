using System.IO;

namespace Heals.CSX.Mall
{
    public static class MallConsts
    {
        public const string DbTablePrefix = "M_";

        public const string DbSchema = null;

        public static string MallDomainModuleAppPath = Path.GetDirectoryName(typeof(MallDomainModule).Assembly.Location);

        public const string MallPictureSubFolder1 = "wwwroot";
        public const string MallPictureSubFolder2 = "product";
        public const string MallPictureSubFolder3 = "images";

        public const string MallSiteDomain = "http://23.101.29.57:8099";
        //public const string MallSiteDomain = "http://localhost:8033";

        public const string MallSitePicturePath = "product/images";

        public const int TargetDeliveryDays = 3;

        public const string OrderDateFormat = "ddMMyyyy";

        public const string MallClaimTypeUserName = "username";

        public const string MallClaimTypeUserId = "userid";

        public const string HealsOperatorMailbox = "muriel@softlinkmedical.com.hk";

    }
}
