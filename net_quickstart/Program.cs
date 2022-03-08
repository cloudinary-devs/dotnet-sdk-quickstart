using System;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
//using dotenv.net;

namespace net_quickstart
{
    class MainClass
    {
        public static void Main()
        {

            //Config

            //DotEnv.Load();
            //Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            Cloudinary cloudinary = new Cloudinary("<cloudinary_url>");

            //Upload

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"https://res.cloudinary.com/demo/image/upload/cld-sample.jpg"),
                PublicId = "Testing"
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            Console.WriteLine(uploadResult.JsonObj);

            //Admin

            var getResourceParams = new GetResourceParams("Testing")
            {
                QualityAnalysis = true
            };
            var getResourceResult = cloudinary.GetResource(getResourceParams);
            Console.WriteLine(getResourceResult.JsonObj);

            //Transformation

            var myTransformation = cloudinary.Api.UrlImgUp.Transform(new Transformation()
                .Width(150).Crop("scale").Chain()
                .Effect("cartoonify"));

            var myUrl = myTransformation.BuildUrl("Testing");
            var myImageTag = myTransformation.BuildImageTag("Testing");

            Console.WriteLine(myUrl);
            Console.WriteLine(myImageTag);
        }
    }
}
