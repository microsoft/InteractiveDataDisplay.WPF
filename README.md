Interactive Data Display for WPF
================================

Interactive Data Display for WPF is a set of controls for adding interactive visualization of dynamic data to your application. It allows to create line graphs, bubble charts, heat maps and other complex 2D plots which are very common in scientific software. Interactive Data Display for WPF integrates well with Bing Maps control to show data on a geographic map in latitude/longitude coordinates. The controls can also be operated programmatically.

How to use
----------
Drawing with Interactive Data Display is easy. 

One line of C# code to draw simple linegraph:
````c#
linegraph.Plot(x,y); // x and y are IEnumerable<double>
````
And corresponding XAML snippet:
````xaml
<d3:Chart BottomTitle="Argument" LeftTitle="Function">
     <d3:LineGraph x:Name="linegraph" Description="Simple linegraph" Stroke="Blue" StrokeThickness="3"/>
</d3:Chart> 
````
If we get arrays `x` and `y` as:
````c#
var x = Enumerable.Range(0, 1001).Select(i => i / 10.0).ToArray();
var y = x.Select(v => Math.Abs(v) < 1e-10 ? 1 : Math.Sin(v) / v).ToArray();
````
We will receive:

<img src="/images/sinline.PNG" align="center" height="300" width="415" margin="auto">

Other Interactive Data Display samples:

<img src="/images/line.PNG" align="left" height="300" width="415" >
<img src="/images/markers.PNG" align="left" height="300" width="415" >
<img src="/images/heatmap.PNG" align="left" height="300" width="415" >
<img src="/images/barchart.PNG" align="left" height="300" width="415" >
<img src="/images/map.PNG" align="center" height="300" width="415" margin="auto">

See the source code [here](https://github.com/Microsoft/InteractiveDataDisplay.WPF/tree/master/samples).

Licensing
---------

Interactive Data Display for WPF is under the [MIT license](https://github.com/Microsoft/InteractiveDataDisplay.WPF/blob/master/LICENSE).

Other 
-----
There is also [Interactive Data Display](https://github.com/predictionmachines/InteractiveDataDisplay) for Javascript. You can see interactive samples [here](http://predictionmachines.github.io/InteractiveDataDisplay).

Contributing
------------

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
