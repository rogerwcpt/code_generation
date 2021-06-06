<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >
    <xsl:output indent="yes" omit-xml-declaration="yes" media-type="html" />
    <xsl:template match="/PersonModel">
        <h1>Output of Person Xsl Template</h1>
        <h2>User Details</h2>
        <h3>FirstName: <xsl:value-of select="FullName"/></h3>
        <h3>Company: <xsl:value-of select="Company"/></h3>
        <h3>Skills:</h3>
        <ul>
            <xsl:for-each select="Skills/string">
                <li><xsl:value-of select="."/></li>
            </xsl:for-each>
        </ul>
        <h5>Sample C# Generated Code</h5>
        <pre>
            <code>
                public class PersonModel
                {
                public string FullName { get; set;  }
                public string EmailAddress { get; set;  }
                public string[] Skills { get; set;  }
                public string Company { get; set; }
                }
            </code>
        </pre>  
    </xsl:template>
</xsl:stylesheet> 