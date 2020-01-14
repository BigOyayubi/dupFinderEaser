<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <html lang="ja">
      <head>
        <!-- Required meta tags -->
        <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
        <!-- Bootstrap CSS -->
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>
      </head>
      <body>
        <h1>Statistics</h1>
        <table class="table table-bordered">
          <tr>
            <th scope="row">Total code base size</th>
            <td>
              <xsl:value-of select="//CodebaseCost"/>
            </td>
          </tr>
          <tr>
            <th scope="row">Code to analyze</th>
            <td>
              <xsl:value-of select="//TotalDuplicatesCost"/>
            </td>
          </tr>
          <tr>
            <th scope="row">Total size of duplicated fragments</th>
            <td>
              <xsl:value-of select="//TotalFragmentsCost"/>
            </td>
          </tr>
        </table>

        <h1>Detected Duplicates</h1>
        <xsl:for-each select="//Duplicates/Duplicate">
          <xsl:variable name="duplicateIndex" select="position()"/>
          <h4>
            Duplicated Fragments: <xsl:value-of select="$duplicateIndex"/>
          </h4>

          <h5>
            Overview
          </h5>
          
          <table class="table table-bordered">
            <tr>
              <th scope="row">
                Size
              </th>
              <td>
                <xsl:value-of select="@Cost"/>
              </td>
            </tr>
            <xsl:for-each select="Fragment">
              <xsl:variable name="i" select="position()"/>
              <tr>
                <th>
                  Fragment <xsl:value-of select="$i"/>
                </th>
                <td>
                  <xsl:value-of select="FileName"/>:<xsl:value-of select="LineRange/@Start"/>-<xsl:value-of select="LineRange/@End"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>

          <h5>
            Detail
          </h5>
          
          <table class="table table-bordered">
            <tr>
              <xsl:for-each select="Fragment">
                <xsl:variable name="i" select="position()"/>
                <th>
                  Fragment
                  <xsl:value-of select="$i"/>
                </th>
              </xsl:for-each>
            </tr>
            <xsl:for-each select="Fragment">
              <xsl:variable name="i" select="position()"/>
              <td>
                <pre>
                  <xsl:value-of select="Text"/>
                </pre>
              </td>
            </xsl:for-each>
          </table>
        </xsl:for-each>
        <!-- Optional JavaScript -->
        <!-- jQuery first, then Popper.js, then Bootstrap JS -->
        <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
