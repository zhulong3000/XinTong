#信通中国 视图层文档

<code>
  <!-- 
  子页面模板
      @{
        ViewBag.Title = "Home 信通首页"; @*  页面标题 *@
        ViewBag.Menu = 0;  @*  页脚导航定位 *@
      }
      @section featured {
      }
      @* 页面的样式表连接 *@
      @section link{
        <link rel="stylesheet" href="../../Content/css/owl.carousel.css" type="text/css">
        <link rel="stylesheet" href="../../Content/css/owl.theme.css" type="text/css">
        <link rel="stylesheet" href="../../Content/css/index.css" type="text/css">
        }
      @* 页面的样式表连接 *@


      @* 页面的主要内容 *@
      @* 页面的主要内容 *@

      @* 页面的脚本文件 *@
      @section scripts{
      <script src="../../Scripts/js/require.js" data-main="../../Scripts/js/index.js"></script>
      }
      @* 页面的脚本文件 *@
    -->
</code>