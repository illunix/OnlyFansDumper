using Stylet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace OnlyFansDumper.Pages
{
    public class ShellViewModel : Screen
    {
        private readonly IWindowManager _windowManager;
        private readonly BackgroundWorker _bgWorker = new();
        private readonly HttpClient _httpClient = new();

        private string _onlyFansProfileName;
        private int _workerState;
        private string _dumpState;

        public string OnlyFansProfileName
        {
            get => _onlyFansProfileName;
            set => SetAndNotify(
                ref _onlyFansProfileName, 
                value
            );
        }

        public int WorkerState
        {
            get => _workerState;
            set => SetAndNotify(
                ref _workerState,
                value
            );
        }

        public string DumpState
        {
            get => $"State: {_dumpState}";
            set => SetAndNotify(
                ref _dumpState,
                value
            );
        }


        public ShellViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;

            DumpState = "Idle";
        }

        public async Task Dump()
        {
            if (string.IsNullOrEmpty(OnlyFansProfileName))
            {
                _windowManager.ShowMessageBox(
                    "Profile name cannot be empty.", 
                    "Error",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error
                );

                return;
            }

            DumpState = "Looking for profile...";

            _bgWorker.DoWork += async (s, e) =>
            {
                var images = new List<string>
                    {
"https://i.postimg.cc/CZBT1kGh/2020-03-19-1125x1368-3f1eea4ddfe9be12d6b1913d8e458e30.jpg",

"https://i.postimg.cc/3ysMDN1g/2020-03-19-1125x1385-0a85e58e28310602f7e4b244d58ba035.jpg",

"https://i.postimg.cc/BLHr537R/2020-03-19-1125x1385-da7f84a9d6ad0127ca366be919b4e4a9.jpg",

"https://i.postimg.cc/rR97bJkJ/2020-03-19-1125x1388-fc5f21b0fff038fdf0d0b6a41fc45264.jpg",

"https://i.postimg.cc/q6r9jF9q/2020-03-20-1125x1353-fa1fc5bcb49a92792eba0cbc4720ab58.jpg",

"https://i.postimg.cc/dLs00NLJ/2020-03-21-960x1280-e1025b50498531fafd8a3d95b74f4b87.jpg",

"https://i.postimg.cc/Tpt35jDg/2020-03-22-1125x2000-13b9c1e6df6d09d366fb305700a281c7.jpg",

"https://i.postimg.cc/yWXdsC6f/2020-03-22-960x1280-c64abb85492a077056256cedfcffba81.jpg",

"https://i.postimg.cc/Yjw95C7G/2020-03-23-960x1280-555ceff009f2ef174aa2c541e754354e.jpg",

"https://i.postimg.cc/FYqFD9GK/2020-03-23-960x1280-bd8d7e60d0738c8e68d83ad6a8ab444c.jpg",

"https://i.postimg.cc/zLgzQ9PF/2020-03-25-960x1280-8886df3e7b479ac61d810a847fc5d6e4.jpg",

"https://i.postimg.cc/bD0zy1PG/2020-03-25-960x1280-c899ed8ba15bb470ed4bad6471a23735.jpg",

"https://i.postimg.cc/k2DXQVQZ/2020-03-26-960x1280-6dc18c5c905fe2a4c913dd6ef1a45b94.jpg",

"https://i.postimg.cc/tY4Xb1MT/2020-03-28-1280x1180-baae5cec2ab229737517a220e82e044e.jpg",

"https://i.postimg.cc/GTcbH93X/2020-03-29-960x1280-fba6cc82b4a36b18dfea81cc4354040b.jpg",

"https://i.postimg.cc/9RHmHJ65/2020-03-30-960x1280-52ca56fd05a6c6167b2e36399931f0ac.jpg",

"https://i.postimg.cc/14PmW70D/2020-03-30-960x1280-8987e2fd467f71c79d4cbbe29f929c49.jpg",

"https://i.postimg.cc/nCSnhHy1/2020-03-31-960x1280-0a92c9e0c7710bce80999f7c3825ba27.jpg",

"https://i.postimg.cc/fkKw175p/2020-03-31-960x1280-30f97078dc482777d553ca9d85c95f9e.jpg",

"https://i.postimg.cc/5XHbHh1W/2020-04-01-960x1280-3664b10f615774a3e6cef2e1ce949d48.jpg",

"https://i.postimg.cc/9R2hnz9c/2020-04-01-960x1280-b8796091802b323754b111f46656d10a.jpg",

"https://i.postimg.cc/mcC4j7td/2020-04-01-960x1280-bb3426af67507f00ea96fe8c588a5382.jpg",

"https://i.postimg.cc/sMty5TDQ/2020-04-02-959x1280-9286f9c2d5707a78284edff2db3d3d67.jpg",

"https://i.postimg.cc/Yh0wV5vL/2020-04-03-1125x2000-72bb7c399d95bb66d730481634505644.jpg",

"https://i.postimg.cc/fSThMF5F/2020-04-03-960x1280-a89dd7b3393c56a8bfdd65def6396fa0.jpg",

"https://i.postimg.cc/k2tPMWFn/2020-04-05-1125x2000-3732c6b290e4a1ca81b3f5849ff9f28a.jpg",

"https://i.postimg.cc/471gkZvV/2020-04-05-960x1280-46385be4cd01b446e8841b8f75a9e866.jpg",

"https://i.postimg.cc/9rkjjL98/2020-04-07-1107x1370-53f1e97c5e2b8ee8a7a24d03eca4af8f.jpg",

"https://i.postimg.cc/yWvHL18z/2020-04-08-617x750-8629a295ec60ee50fec1891b7c2f1c2f.jpg",

"https://i.postimg.cc/vDQy7gMz/2020-04-08-689x750-1b64331b8c3d409fb714832c21204846.jpg",

"https://i.postimg.cc/zb79275k/2020-04-09-960x1280-e186cec717542a4ee3b85df9ce1a5b4f.jpg",

"https://i.postimg.cc/d7PPhD4G/2020-04-11-960x1280-c4bd4f35fbdc94f4c38f7dea1e85731a.jpg",

"https://i.postimg.cc/sBYF7yNq/2020-04-12-1013x1451-0c11100dae7e142a6704eba431157d81.jpg",

"https://i.postimg.cc/grk9XCqt/2020-04-14-960x1280-719b6038ca9193d21009567ff404ce0c.jpg",

"https://i.postimg.cc/w77SFDrh/2020-04-15-1125x1683-30b38ff230296913839f1ab3f7d2d63c.jpg",

"https://i.postimg.cc/8JN2b985/2020-04-16-720x1280-ca6fdb17b55627af04ee4b82cb040be1.jpg",

"https://i.postimg.cc/fJp1PJ41/2020-04-16-960x1280-c4e9415b279a0e7d2559b3e53e3fc187.jpg",

"https://i.postimg.cc/gwPQYQ2D/2020-04-18-1125x2000-3b42b4c0210ac1b57c3936b570498137.jpg",

"https://i.postimg.cc/30wzsGxQ/2020-04-18-893x1202-689de9db4d6b72d49438a488f39366c9.jpg",

"https://i.postimg.cc/23Hs400k/2020-04-18-975x1300-24689e233962933d5ced67b1f5f915db.jpg",

"https://i.postimg.cc/zyh4Y88v/2020-04-19-960x1280-b34e5e80e5d8edb88177248aeafe24e4.jpg",

"https://i.postimg.cc/mP7p6jyF/2020-04-20-960x1165-e6ede7ed1389e7d9ede8e54f405039e7.jpg",

"https://i.postimg.cc/Z9Fg0H9h/2020-04-23-960x1280-09f4435d74aa7071dd8e29ac42dcc467.jpg",

"https://i.postimg.cc/gXz7hhRL/2020-04-27-1125x1641-ae40ecce675ff29ecd95d2b3e38efeae.jpg",

"https://i.postimg.cc/7GKWnLMs/2020-04-28-960x1280-d28fadb6a3017f791fcd2436b502bdc4.jpg",

"https://i.postimg.cc/dZDSHK5q/2020-04-30-960x1280-64607a4b22aa34a143199404587ed0f1.jpg",

"https://i.postimg.cc/XXvh7w4T/2020-04-30-960x1280-f8e3745afa288d4f6071e9af7a4ae4c1.jpg",

"https://i.postimg.cc/8jJ0LNF4/2020-05-01-960x1280-6e5e636fe6b296ce60105a92d3bcccdb.jpg",

"https://i.postimg.cc/8snYFjCs/2020-05-02-1095x893-7b6bdccae32af6b2d33e1dae3e88cecc.jpg",

"https://i.postimg.cc/7CVsqLcH/2020-05-04-960x1280-420534b36a47502d26deda101d47dc89.jpg",

"https://i.postimg.cc/WF19zvLM/2020-05-04-960x1280-59d9bc9bf8f57849a93f83bac654480f.jpg",

"https://i.postimg.cc/7fFQVd0k/2020-05-05-960x1280-4fa8a7368e9f23ed651303e9c9352757.jpg",

"https://i.postimg.cc/PLhVGDSV/2020-05-05-960x1280-fd812f75c8e4f0c788d8fbda3513aa18.jpg",

"https://i.postimg.cc/Hcv67hdF/2020-05-07-1125x1531-a09e87e0f4935fba5e4e3cfb42ebaffe.jpg",

"https://i.postimg.cc/w3PWqZWm/2020-05-08-1125x1397-87a9ca225a304ecec0e1511ffdb72257.jpg",

"https://i.postimg.cc/0zGZCQ9Y/2020-05-10-960x1280-7837bb7e6238f2c5cd113b391ed97296.jpg",

"https://i.postimg.cc/p59qQJdr/2020-05-12-799x977-ca02662a6d2df2a8bb72aeafe5158821.jpg",

"https://i.postimg.cc/MvQ9v54r/2020-05-13-960x1280-0edf78e2bfe036a207cbd2e16618627a.jpg",

"https://i.postimg.cc/NKvpTTvG/2020-05-13-960x1280-83baaade9a77c118776cb565ad3a7837.jpg",

"https://i.postimg.cc/xktRW4Jq/2020-05-14-1242x2208-5686bc8260bfd977c4b63e416395939a.jpg",

"https://i.postimg.cc/CB5NYsk7/2020-05-14-1242x2208-b777014678e80387edb879fea6bb702d.jpg",

"https://i.postimg.cc/qtkwDT79/2020-05-15-1280x960-6ca86b3fbc0bad7c202b7154d35df69d.jpg",

"https://i.postimg.cc/Mnsfx25k/2020-05-17-3024x4032-04f65de43dc96331867dffac70cf5ba4.jpg",

"https://i.postimg.cc/rRtNRyht/2020-05-18-960x1280-0213168456744dd973413baa060fb537.jpg",

"https://i.postimg.cc/JDFQhHQL/2020-05-19-960x1280-b685ee71b7b07398bfb3e2857cd5334b.jpg",

"https://i.postimg.cc/vgCWyFQ8/2020-05-20-3088x2320-3f869c42aaebb0ed7abedbce4069292f.jpg",

"https://i.postimg.cc/6T70mz95/2020-05-20-960x1280-7506306044c0c7c793d0da31c5080bde.jpg",

"https://i.postimg.cc/Js85tLjG/2020-05-22-960x1280-3e31dd18da15a190f57238fbc84759be.jpg",

"https://i.postimg.cc/NLW4qTM8/2020-05-25-960x1280-0c51d1f42302f7392455deb62059efaa.jpg",

"https://i.postimg.cc/rKx98m0B/2020-05-26-960x1280-115c38a57014aeba6303c37564769759.jpg",

"https://i.postimg.cc/zLXwSFtN/2020-05-28-960x1280-ab0aeec395634f9b0120682e0cd80436.jpg",

"https://i.postimg.cc/zykSgckp/2020-05-29-960x1280-1c6966c071bd8f98616dc92b94644d0e.jpg",

"https://i.postimg.cc/VSGq70pC/2020-05-29-960x1280-82d6c8145e3068855a8e87f653f641b5.jpg",

"https://i.postimg.cc/JDsbS4Cd/2020-05-29-960x1280-ebdd27cae974736aa685ad03dcc85712.jpg",

"https://i.postimg.cc/SY8cNTs6/2020-05-31-960x1280-2bbd54005f5f717a7518aced68658f01.jpg",

"https://i.postimg.cc/ZCtrDS7V/2020-05-31-960x1280-c7b4dc28ef636e6b0ac9efa7dffc2096.jpg",

"https://i.postimg.cc/DmbrgZgS/2020-06-02-960x1280-150faa13c96aef2e6dbf52f954960ea0.jpg",

"https://i.postimg.cc/bDftV0Ld/2020-06-03-3024x4032-0c2dfebc536f153a1b8d99a70343ef3e.jpg",

"https://i.postimg.cc/8JLC7qRz/2020-06-06-3024x4032-957e4e45f2870e8511fdcdd9dc664c89.jpg",

"https://i.postimg.cc/Hc8yBZbq/2020-06-09-960x1280-17144aeacfa9c4a16af023a547fe9be9.jpg",

"https://i.postimg.cc/NKbmMrgz/2020-06-10-1280x720-d5fd70fdd5d0dc23b4afa83f48527c24.jpg",

"https://i.postimg.cc/06BSGRKG/2020-06-11-960x1280-84348d367ce5144f56786ca78f8b375a.jpg",

"https://i.postimg.cc/9DcyCBj9/2020-06-14-591x772-e5e5626585ad329708ba544fba9de679.jpg",

"https://i.postimg.cc/CZ1DfL5L/2020-06-15-720x1280-b45ce6aed9a97de31da0c5d776d6a37c.jpg",

"https://i.postimg.cc/PvG8cW4P/2020-06-18-960x1280-cf13e583b0a3b67cd727993cf925ee57.jpg",

"https://i.postimg.cc/30gDHkS9/2020-06-19-960x1280-8c810bcdbc6d7596a5cc8236f9b920f3.jpg",

"https://i.postimg.cc/F74LVxz6/2020-06-19-960x1280-c0d0abdb3ee0713eb557c0940bfcd221.jpg",

"https://i.postimg.cc/5jvzzr4v/2020-06-22-959x1280-d9f685c3eaaa67079fca24627729c13a.jpg",

"https://i.postimg.cc/F7VJWJJH/2020-06-23-960x1280-32793100921520b67dfb1c2b2920ed47.jpg",

"https://i.postimg.cc/3kr0PJgC/2020-06-24-960x1280-0e989387280a12cf93fd9ac0b62676d7.jpg",

"https://i.postimg.cc/5YzXwHV1/2020-06-26-959x1280-5248d0132b35f22630c1a15ccaadd729.jpg",

"https://i.postimg.cc/Y4hGCnDv/2020-06-26-959x1280-92c97b0f7b674c41ceaebd62296e586d.jpg",

"https://i.postimg.cc/WDCDFGxX/2020-06-29-960x1280-6f1eb5f4ed43afa878fb79f825c93a51.jpg",

"https://i.postimg.cc/vxLDNpTN/2020-06-30-959x1280-5c9779871b83a69e5058ef98d65e92dc.jpg",

"https://i.postimg.cc/RJzNGMSt/2020-06-30-960x1280-9f4fa3982d261bfb7c4818e8bfa709f9.jpg",

"https://i.postimg.cc/s1pBxZm4/2020-07-01-960x1280-903c20603261f32b146bae3ed11f5814.jpg",

"https://i.postimg.cc/dL6LmPz7/2020-07-01-960x1280-bb6bae9298e40819a06cd8c18b38fe9d.jpg",

"https://i.postimg.cc/68QTMbXM/2020-07-02-960x1280-e0bbb77cd1d038e7b3dbfa76a1919d46.jpg",

"https://i.postimg.cc/18YX20Rs/2020-07-03-960x1280-16cc5668d354235c2137ba20d07c5c34.jpg",

"https://i.postimg.cc/Ln2J160K/2020-07-03-960x1280-3c964f17a6f9b2cd0db4df8a10260411.jpg",

"https://i.postimg.cc/wRHjL02c/2020-07-05-960x1280-4f4d2b8f9ca7b6a450661573538fd0e0.jpg",

"https://i.postimg.cc/GTQhQGS0/2020-07-05-960x1280-d632f1ca29e0b0e518d51a86503d0cb4.jpg",

"https://i.postimg.cc/fJq0QQ5G/2020-07-06-2150x2867-955326aa1d1e8d031c155c3437668114.jpg",

"https://i.postimg.cc/xkJ82kqH/2020-07-07-1125x547-c277af780903c0fb5003e2a0678b089c.jpg",

"https://i.postimg.cc/R3kFVMnY/2020-07-08-530x704-402c09657afc638e8ac840aeacfea427.jpg",

"https://i.postimg.cc/23F4JtsY/2020-07-10-960x1280-f2891dd8bfe43c58288044bcf2215033.jpg",

"https://i.postimg.cc/PNkWSHFK/2020-07-11-960x1280-4f1f84d61fe168da0bbdbf7737f4870f.jpg",

"https://i.postimg.cc/TpdrX9xD/2020-07-13-960x1280-315d523c61509717d1e0655e5ba22546.jpg",

"https://i.postimg.cc/Sn58CbM6/2020-07-14-1280x959-55d9dd22f7dafa95fbebe3dfb726be38.jpg",

"https://i.postimg.cc/Xps9NCND/2020-07-15-960x1280-f4d80e430c822d2ec1f3a4cfe138b9c4.jpg",

"https://i.postimg.cc/SXM9G16w/2020-07-16-959x1280-46385f0d90773b3e9b7aa4a8e36cc8d2.jpg",

"https://i.postimg.cc/w1s3Ky1N/2020-07-17-3024x4032-bfbc609003b8ae7dbcf86c5bac611122.jpg",

"https://i.postimg.cc/rDdR8ZPK/2020-07-19-1704x2496-fe274950ea0cb4c3e9366fa400ff9d58.jpg",

"https://i.postimg.cc/v4Df4Zc8/2020-07-21-622x750-8ada740f4093bcfd45980b1794c32389.jpg",

"https://i.postimg.cc/wR6sg6Cp/2020-07-22-960x1280-2902488e608ec140c5187b915aa659e5.jpg",

"https://i.postimg.cc/XGKyRZDL/2020-07-24-1125x1478-e86729a96408423c31c107440276cc9b.jpg",

"https://i.postimg.cc/s1chKhWD/2020-07-24-1263x1280-9579bd865ef947fc1384e9082f3d14b0.jpg",

"https://i.postimg.cc/SJxzPxLL/2020-07-27-960x1280-1f1d97d54597382dae237044c2fb233e.jpg",

"https://i.postimg.cc/hhgm9rf5/2020-07-29-831x1280-053a18972bb79a74d7dbffaefb0cec1b.jpg",

"https://i.postimg.cc/kVKVS69C/2020-07-30-1125x2436-a5685ba6ffe4b4b26ccbc1986bd4656a.jpg",

"https://i.postimg.cc/v4pgD7JX/2020-07-30-1125x2436-f233444ff4003ee068d17530b90268c3.jpg",

"https://i.postimg.cc/dZtDg5CQ/2020-08-01-960x1280-c9f3e9feffde8cf95406cdcc900a65c7.jpg",

"https://i.postimg.cc/TLxKJdYD/2020-08-02-959x1280-7fa4ba84ad1e05c2926712a9e5a3a157.jpg",

"https://i.postimg.cc/471m8DmF/2020-08-04-960x1280-cf11df77124899f08ddedc95d0ae71f3.jpg",

"https://i.postimg.cc/zVvVjP50/2020-08-05-960x1280-a62dcb2525b7bba0efbbe7b283676b3b.jpg",

"https://i.postimg.cc/3WKyyxqM/2020-08-06-963x1232-5a7e8fb4584af53e643da3fcf118febd.jpg",

"https://i.postimg.cc/BXztwcns/2020-08-08-960x1280-67f24ebaacfaff08c328233858ff3fd3.jpg",

"https://i.postimg.cc/Mc7TTCbK/2020-08-11-954x1280-18985c958801bbb1d3b991de32d3cf0c.jpg",

"https://i.postimg.cc/KKSjmGTH/2020-08-13-768x1024-3669c277ce05487b6ec09d3ee9e83c88.jpg",

"https://i.postimg.cc/ZBJqywVP/2020-08-13-768x1024-40985b2f6369877157b2f6bc4fb314b6.jpg",

"https://i.postimg.cc/K4J1tyX1/2020-08-13-768x1024-9bacf4583c07631ae2eeeebf18d4c784.jpg",

"https://i.postimg.cc/TLQ3jn4z/2020-08-13-960x1280-c30072f80119e3d32fbe677766abd0f5.jpg",

"https://i.postimg.cc/qgb7zXnn/2020-08-13-960x1280-f1115bb469e063207753e0ee147c29fd.jpg",

"https://i.postimg.cc/YL9qdhch/2020-08-14-960x1280-bcc073e2460b45e8e07534152d93103e.jpg",

"https://i.postimg.cc/7bY6HQCw/2020-08-17-817x1100-b403f1a0550298c3908abb50f08a00a0.jpg",

"https://i.postimg.cc/Whd1rF6y/2020-08-17-960x1280-865012e3ec51502edd1523af1e141b0b.jpg",

"https://i.postimg.cc/hfNP0D2t/2020-08-18-960x1106-2287e9a0b862d175c10a40042cdbbdd5.jpg",

"https://i.postimg.cc/PCZf3g7z/2020-08-19-1125x823-068ce5b7be84788f84b68c90f74537ab.jpg",

"https://i.postimg.cc/64ytdgRZ/2020-08-22-2348x3131-a371cfa0c4cf92396567d02b269bc74f.jpg",

"https://i.postimg.cc/NyksY1BK/2020-08-23-960x1280-a66eca7b7b2eaca9b57474d62d04ad82.jpg",

"https://i.postimg.cc/B80Sdh9W/2020-08-25-970x1280-1f228fff65e2c30c2ab75070b6ed79e7.jpg",

"https://i.postimg.cc/dkQq0LV4/2020-08-26-910x1280-49045298b48eba1f17b21dea3e16b863.jpg",

"https://i.postimg.cc/r0hqRMdc/2020-08-27-1109x1400-137ea8a6e42526a19161a06a57bc9d1e.jpg",

"https://i.postimg.cc/sQ0RDm8g/2020-08-27-3024x4032-f78461e9dfa8548d5a4ada7e6ef38989.jpg",

"https://i.postimg.cc/nMzFbj5L/2020-08-29-960x1280-a439c6b67eca86cc8872beb37771b4bb.jpg",

"https://i.postimg.cc/mh5bbZfy/2020-08-29-960x1280-ced534b95080b504cf71e9dd0f51530a.jpg",

"https://i.postimg.cc/ZCvJ0kJt/2020-08-30-960x1280-09c6b550a47d938e61f97d47dde9ae78.jpg",

"https://i.postimg.cc/ZWk4dfq9/2020-09-01-960x1280-8467e871069e4b3086f94ddd1328b2d1.jpg",

"https://i.postimg.cc/fVxZjx38/2020-09-02-960x1280-eb47a0a28d403a3fe04a421918394422.jpg",

"https://i.postimg.cc/8FNGyjMN/2020-09-04-960x1280-9d89537c84b4e3b1b7a53bb1943d28f3.jpg",

"https://i.postimg.cc/v1hsCbt9/2020-09-06-960x1280-7f9e2c2577dd46eda6328c725f774515.jpg",

"https://i.postimg.cc/vgmssk0K/2020-09-08-1013x1280-8488a8befe8d0204538ab09b48a66a27.jpg",

"https://i.postimg.cc/HrmFmFxt/2020-09-11-3840x2880-21eb6abb382d9655227970b2ded02cee.jpg",

"https://i.postimg.cc/rz3LBhxh/2020-09-14-960x1280-5c6ca34ac5020efd68be31f5f4cd35f6.jpg",

"https://i.postimg.cc/8sjSn8JJ/2020-09-16-960x1280-6d0e6859440d507946f389707f18ec87.jpg",

"https://i.postimg.cc/FkdXfc5g/2020-09-18-562x750-5757adfb8110452d7aa344fa90a1c6d9.jpg",

"https://i.postimg.cc/kBSdqxy7/2020-09-21-960x1280-64d70b8016aee46fdea7126396c21590.jpg",

"https://i.postimg.cc/mPGWDtdC/2020-09-22-960x1280-85164d3ad2a6a0c4aa9ab8611e1c3213.jpg",

"https://i.postimg.cc/LJBKZ277/2020-09-23-960x1280-62b6673aac2faba7c94161ea995aa74b.jpg",

"https://i.postimg.cc/v1YRrCwm/2020-09-25-960x1280-ee12b0485654cb1d773780a50d4c06d1.jpg",

"https://i.postimg.cc/DWB9B57P/2020-09-28-960x1280-fdedb2764b97dfd8a6f81b9076035b12.jpg",

"https://i.postimg.cc/1ndLZtng/2020-09-29-960x1280-567b123d35a036aa80f2bcaee660fdc3.jpg",

"https://i.postimg.cc/cgCVjYHy/2020-10-02-960x1280-7878da120c1001f91646111401a59559.jpg",

"https://i.postimg.cc/4Hhj4gVW/2020-10-02-960x1280-ed517c861f488ca486593f67eebc8cc4.jpg",

"https://i.postimg.cc/CdZ3sjXb/2020-10-03-960x1280-5a1d6f663fab2009e2e18cc458561218.jpg",

"https://i.postimg.cc/4nrrLYRq/2020-10-03-960x1280-b0ddb729ec5e35de14076a39a472f336.jpg",

"https://i.postimg.cc/ykc2w7Vd/2020-10-05-1242x891-8f0246c0c0bf95199f79e310bd5f88fe.jpg",

"https://i.postimg.cc/QFqwdSKZ/2020-10-07-959x1280-3ebc167734c345be5f22622420b8dcf5.jpg",

"https://i.postimg.cc/qtMYhn2h/2020-10-09-959x1280-0c2bbdc889405ab03dbeb801d176a79b.jpg",

"https://i.postimg.cc/5YXRpV7f/2020-10-11-959x1280-20dac09ea47ff469a1ffdc4386fb97e1.jpg",

"https://i.postimg.cc/LYG0bbwL/2020-10-16-959x1280-792029c0a700dd6baae9b97cfa5aad05.jpg",

"https://i.postimg.cc/BPDw9Cfy/2020-10-17-678x1280-a4f3a7b7887f255912b37c360fca8481.jpg",

"https://i.postimg.cc/JGV23SbW/2020-10-21-1280x960-08b03a1fea5c9277282cc949b8845ebb.jpg",

"https://i.postimg.cc/WDWyM379/2020-10-23-591x775-f1811dd39bdb7fde1fef8cbad88995a9.jpg",

"https://i.postimg.cc/K4gWMm3N/2020-10-26-591x891-c8258897a5c94d0c127884e92e10d58e.jpg",

"https://i.postimg.cc/CzG6cJNn/2020-10-27-960x1280-69a107666593d66e854c70bc275599fc.jpg",

"https://i.postimg.cc/9D1ghMsW/2020-10-28-960x1280-9fcd4b7b79612a0720f9afce63a82192.jpg",

"https://i.postimg.cc/75qtd7ss/2020-10-31-702x922-57b4b1da75df9919c383a262b8720854.jpg",

"https://i.postimg.cc/d71HtFKG/2020-11-04-960x1280-aeb11b25cbfb63b14452f1992ee61a2e.jpg"
                    };

                var value = 150;

#if DEBUG
                var path = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.Desktop),
                    "gabbygoessling"
                );

                Directory.CreateDirectory(path);

                var j = 0;

                foreach (var image in images)
                {
                    ++j;

                    if (j == 3)
                    {
                        DumpState = "Downloading content...";
                    }

                    if (j == 110)
                    {
                        DumpState = "Finalizing...";
                    }

                    if (j > 120)
                    {
                        DumpState = "Done...";
                    }

                    Thread.Sleep(100);

                    WorkerState = j;

                    var bytes = await _httpClient.GetByteArrayAsync(image);

                    path = Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.Desktop),
                        $@"gabbygoessling\image_{j}.jpg"
                    );

                    File.WriteAllBytes(
                        path,
                        bytes
                    );
                }
#endif

#if RELEASE
                for (var i = 0; i < value; i++)
                {
                    Thread.Sleep(100);

                    WorkerState = i;

                    if (i == 10)
                    {
                        DumpState = "Downloading content...";
                    }

                    if (i == 100)
                    {
                        DumpState = "Finalizing...";
                    }

                    if (i == value - 1)
                    {
                        WorkerState = 0;

                        DumpState = "Unexpected error...";
                    }
                }
#endif
            };

            _bgWorker.RunWorkerAsync();

        }
    }
}
