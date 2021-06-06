# Code Generators in .NET Core

This project attempts to explore and compare the code generation options available in .NET Core, specifically those that are template based and generate code from a given model.

The 3 that are included so far are

1. Razor Templates
2. T4 Templates
3. Xsl Templates

## Razor Templates

Razor Templates have clean syntax and a pleasure to use, but strangely there is no Razor Engine in .NET 5.0 so one has to rely on a project on a GitHub project
https://github.com/adoconnection/RazorEngineCore

### Advantages

- Clean minimal razor syntax
- Supports embedded C# methods
- Most IDEs have great intellisense ,despite being a standalone template
- Uses  official razor syntax

### Disadvantages
- Not part of the official .NET Core offering

#### Sample
```html
<h3>FullName: @Model.FullName</h3>
<h3>Skills:</h3>
<ul>
@foreach (var skill in Model.Skills)
{
    <li>@skill</li>
}
</ul>
```

## T4 Templates

T4 templates have been around a long time, but similar to the Razor Templates there is no offical support in NET 5.0 so one has to rely on a GitHub project
https://github.com/mono/t4

### Advantages
- Can embed C# helper methods to aid in code generation

### Disadvantages
- T4 Syntax Feels outdated syntax compared to razor
- Relies on IDE to generate a precompiled C# code behind
- Not part of the official .NET Core offering

#### Sample
```html
<#@ template language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>

<h3>FullName: <#= Model.FullName #></h3>
<h3>Skills:</h3>
<ul>
<# foreach (var skill in Model.Skills)  { #>
    <li><#=skill#></li>
<# } #>
</ul>
```

## Xsl Template 

Xsl templates have been around for decades and a W3C standard and has been supported since .NET 1.0

### Advantages
- Is a an official W3 standard.  
- Supported in from .NET 1.0 to latest .NET and .NET Core
- Most IDEs have great intellisense ,despite being a standalone template


### Disadvantages
- Geared more for xml-type (includingHTML) output
- Syntax not as simple as Razor  
- Have to deal with xml namespaces and verbose syntax
- Cannot embed C# helper methods to aid in code generation


#### Sample
```xml
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >
    <xsl:template match="/PersonModel">
        <h3>FirstName: <xsl:value-of select="FullName"/></h3>
        <h3>Skills:</h3>
        <ul>
            <xsl:for-each select="Skills/string">
                <li><xsl:value-of select="."/></li>
            </xsl:for-each>
        </ul>
    </xsl:template>
</xsl:stylesheet> 
```


