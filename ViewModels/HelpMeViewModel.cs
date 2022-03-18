using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Caliburn.Micro.Hello
{
    public class HelpMeViewModel : Screen, IViewModel
    {
        public HelpMeViewModel()
        {
            DisplayName = "HelpMe";
        }

        /// <summary>
        /// 这个实例里面少讲了App.xaml的变更,大家可以直接去看这部分代码
        /// </summary>
        public void BuildClick()
        {
           string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247483866&idx=1&sn=73ca9185b2be655d5c965f1600972a03&chksm=a6a822a991dfabbff983d54f358624a7c5e510b7407c50774981a44bd9ada13201b7364bf0b6&token=1300577902&lang=zh_CN#rd";
           Process ie = Process.Start("iexplore.exe",url);
        }

        public void ExampleFirstClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247484167&idx=1&sn=d3c20f9f8c584789d36c09b2c4d8f2f8&chksm=a6a8207491dfa962995478c0c9361027682f3050a0721484b135dba42fac99518f67af468cc6&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void ExampleSecondClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247484887&idx=1&sn=0f3ba623c2f217517568997c9b7e5854&chksm=a6a826a491dfafb2c0f6c2b5e753289b1d676c8325de379627b4b248b9b1a98900b645d70ab6&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void RegularClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485113&idx=1&sn=5b8fcd88451190145423e828b22cdba8&chksm=a6a825ca91dfacdc25f91386aaedeee6ec43f5c7c4e238ed8e8c2776091d2dd001dbe77d3ddf&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void DevClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485098&idx=1&sn=107678da85486b795fe9b414c2322160&chksm=a6a825d991dfaccfe9cc0efd2cc9305b5b93b76d25326c186fa0851091668f445f4b6ad7e89c&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void DatagridClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485112&idx=1&sn=4666c783dffaea622b40e68ec130085b&chksm=a6a825cb91dfacddf5ac7fa156cf7c5c1d7bd7f8c8e57049ba583669b5ce302f917e482a5dd6&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void DispalyClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485151&idx=1&sn=2d372123c02255d0346133feebd1913a&chksm=a6a825ac91dfacba35cdb86510a2a20606110500667740403a759c912df41b4c6417c25cd265&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void ComboboxClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485169&idx=1&sn=a0f0de4fa1a9bf7e8e41315f299da1b8&chksm=a6a8258291dfac94296a7288f0332b5275406972a0b4cf0829a97f506dd74019ec0c1f1346f8&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void SubWindowClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485176&idx=1&sn=92a73f515ca62b62b64b2bba10bef1db&chksm=a6a8258b91dfac9de8b53b46e522d0e0ae99db7a583e8c0cc1297e29e8b89b7f3f7103b81903&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void MefClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485201&idx=1&sn=da8b3710219a415dcd22f12c61d8c2ac&chksm=a6a8246291dfad742bf4776fafdfa50b8d5ba741e373f0f811a7eea06fc7904e0a425aee3060&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void EventClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485347&idx=1&sn=04d3eb6fb40224a1a469163b5c615862&chksm=a6a824d091dfadc61e202277b2ac055bb417321472da10e057f95ebe4f19cae4f97bdedb5d12&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void CaliburnClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485583&idx=1&sn=6b7280e778ac929d949aec95fcbe7fd1&chksm=a6a82bfc91dfa2eab6d7862053a6f0f59c6835150772298ef5abe0af354816a7518bcdcbf0b0&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void ChartControlClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485703&idx=1&sn=8cecc56181d1b16210ae3a4945b0cbb0&chksm=a6a82a7491dfa36200393b02098ad265f646fcce7b0c9dc17d41e6ed7e6e82eb4444348e5797&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void ComboBoxEditClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485748&idx=1&sn=df5ce245834ddc57ad0c1610037e1d62&chksm=a6a82a4791dfa3511aacc5d708d54c74bdabe0c4e36fbd28bb9d2ecb42ba5666022ba2337292&token=918534412&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void ProjectClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485967&idx=2&sn=a1be96b1653d9253695b1893cc1d615c&chksm=a6a8297c91dfa06ab72f2bae70b3480d85477bf3cf338b2757ecd0f5adf0ff417c925ed574b3&token=918534412&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void ToolkitClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485798&idx=1&sn=3b9a1b237a15681568e0672bdb82d7a8&chksm=a6a82a1591dfa303d38aef7a47546c33a6e223e7f9499e8680151008657bc53b45895f193fd0&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void log4netClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485841&idx=1&sn=78f34dfe24d30b473876f04e3899c041&chksm=a6a82ae291dfa3f4addadc491028f848b419d8587bb9d3d733a43dbae68ea0ea41cd41074eeb&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void ExampleThreeClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485843&idx=1&sn=498778644cd770a6b6e12a7252883bcf&chksm=a6a82ae091dfa3f61fe5badc30d2a5353e7e761d0b6885b1a8bb40ca1e60ba4f918603b6e026&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void ObservableCollectionClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485884&idx=1&sn=1e281023bcaf6f659087b0cc43761c6f&chksm=a6a82acf91dfa3d94f85ee21527f035ad897bc2c3013fc4df02c0b6508ef685c1ca8eb409dc4&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void Project2Click()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485896&idx=2&sn=6e4424366321abfd91dea950ef72eefa&chksm=a6a82abb91dfa3ad99e98a37c381568580dc91bef8721b7b9547af93ae0b5effa40722e49682&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void MatchClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485897&idx=1&sn=c7ddcbbfef2e1ad52f658459ef3a6e14&chksm=a6a82aba91dfa3acba154cb10e3a1e5c5e4b4199acbede1fd6c44fe98ce419b54a86fba968eb&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void BackgroudClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247485898&idx=1&sn=bb665c143017f4f1a06c8e2d681c160c&chksm=a6a82ab991dfa3af4a53321676572341205f052e38f7b8ab2d55a18b91dbcb356d3e46ceba26&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void ValueConverterClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247486052&idx=1&sn=d02d92d10049da84b8bd7a5c7946169b&chksm=a6a8291791dfa0013da86e8b3e0cd4a15e4fbfb6906e809132d58bf536062a12878b8f8b0758&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void IndicatorLightClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247486105&idx=1&sn=d0fe857fa8498d76e4fcf55d6f98ed50&chksm=a6a829ea91dfa0fc19da2318ded32e8590ca6a1deb8de81a7adf31ce6066dd093f084874d14b&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void FTPClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247486137&idx=1&sn=302e9727ff6ab1f321b3f290de5b45f1&chksm=a6a829ca91dfa0dcfbb458bbbe1c19854d37c408881844b3878b6e7d2d28eb7c997f41417a9a&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void MemorandumClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247486184&idx=1&sn=69c221fa23ea69379ce43ce06d810e70&chksm=a6a8299b91dfa08de1411cb445b6bfa2d5ea6cf366777003f8c70de5ecdda844c77efdc343a1&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void MenuClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247486250&idx=1&sn=fc9a6910cdd6f7050bb4ff34b1ba1567&chksm=a6a8285991dfa14f81db5a964b4d8dae3108a32d5b73acccf2fe936a05693d6d5e2557b4535d&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }

        public void ConductClick()
        {
            string url = "https://mp.weixin.qq.com/s?__biz=MjM5MjIzMjk4OA==&mid=2247486567&idx=1&sn=d59c308a4fd5e62acd1386370cda4ba9&chksm=a6a82f1491dfa6026053e9d69a5293eefc04ab07b26f0e1e153f19b50550722f2955c5dfbc8d&token=1300577902&lang=zh_CN#rd";
            Process ie = Process.Start("iexplore.exe", url);
        }
    }
}
