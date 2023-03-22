REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/22/2023 8:45:18 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.SchemaMaps
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace graphdb

''' <summary>
''' ```SQL
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("hash_index", Database:="graphdb", SchemaSQL:="
CREATE TABLE IF NOT EXISTS `hash_index` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `hashcode` CHAR(32) NOT NULL COMMENT 'tolower(md5(tolower(term)))',
  `map` INT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;
")>
Public Class hash_index: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="id"), XmlAttribute> Public Property id As Long
''' <summary>
''' tolower(md5(tolower(term)))
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("hashcode"), NotNull, DataType(MySqlDbType.VarChar, "32"), Column(Name:="hashcode")> Public Property hashcode As String
    <DatabaseField("map"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="map")> Public Property map As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `hash_index` (`hashcode`, `map`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `hash_index` (`id`, `hashcode`, `map`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `hash_index` (`hashcode`, `map`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `hash_index` (`id`, `hashcode`, `map`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `hash_index` WHERE `id` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `hash_index` SET `id`='{0}', `hashcode`='{1}', `map`='{2}' WHERE `id` = '{3}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `hash_index` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `hash_index` (`id`, `hashcode`, `map`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, hashcode, map)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `hash_index` (`id`, `hashcode`, `map`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, id, hashcode, map)
        Else
        Return String.Format(INSERT_SQL, hashcode, map)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{id}', '{hashcode}', '{map}')"
        Else
            Return $"('{hashcode}', '{map}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `hash_index` (`id`, `hashcode`, `map`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, hashcode, map)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `hash_index` (`id`, `hashcode`, `map`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, id, hashcode, map)
        Else
        Return String.Format(REPLACE_SQL, hashcode, map)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `hash_index` SET `id`='{0}', `hashcode`='{1}', `map`='{2}' WHERE `id` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, hashcode, map, id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As hash_index
                         Return DirectCast(MyClass.MemberwiseClone, hash_index)
                     End Function
End Class


End Namespace
