using System;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;

namespace net_quickstart
{
    class MainClass
    {
        public static void Main()
        {

            // Set your Cloudinary credentials
            //=================================

            DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));

            Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            cloudinary.Api.Secure = true;

            //Set Cloudinary URL if not using DotEnv
            //Cloudinary cloudinary = new Cloudinary("cloudinary://<api_key:<api_secret>@<cloudname>");

            // Upload an image and log the response to the console
            //=================

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"https://cloudinary-devs.github.io/cld-docs-assets/assets/images/cld-sample.jpg"),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            Console.WriteLine(uploadResult.JsonObj);

            // Get details of the image and run quality analysis
            //==============================

            var getResourceParams = new GetResourceParams("cld-sample")
            {
                QualityAnalysis = true
            };
            var getResourceResult = cloudinary.GetResource(getResourceParams);
            var resultJson = getResourceResult.JsonObj;

            // Log quality analysis score to the console
            Console.WriteLine(resultJson["quality_analysis"]);


            // Transform the uploaded asset and generate a URL and image tag
            //==============================

            var myTransformation = cloudinary.Api.UrlImgUp.Transform(new Transformation()
                .Width(300).Crop("scale").Chain()
                .Effect("cartoonify"));

            var myUrl = myTransformation.BuildUrl("cld-sample");
            var myImageTag = myTransformation.BuildImageTag("cld-sample");

            // Log URL of the transformed asset to the console
            Console.WriteLine(myUrl);

            // Log image tag for the transformed asset to the console
            Console.WriteLine(myImageTag);
        }
    }
}
