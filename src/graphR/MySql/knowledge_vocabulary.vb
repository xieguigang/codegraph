REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/20/2023 5:34:25 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace graphdb

''' <summary>
''' ```SQL
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("knowledge_vocabulary", Database:="graphdb", SchemaSQL:="
CREATE TABLE IF NOT EXISTS `knowledge_vocabulary` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `vocabulary` VARCHAR(255) NOT NULL,
  `description` MEDIUMTEXT,
  `add_time` DATETIME NOT NULL,
  `color` CHAR(7) NOT NULL DEFAULT '#123456',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;")>
Public Class knowledge_vocabulary: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="id"), XmlAttribute> Public Property id As Long
    <DatabaseField("vocabulary"), NotNull, DataType(MySqlDbType.VarChar, "255"), Column(Name:="vocabulary")> Public Property vocabulary As String
    <DatabaseField("description"), DataType(MySqlDbType.Text), Column(Name:="description")> Public Property description As String
    <DatabaseField("add_time"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="add_time")> Public Property add_time As Date
    <DatabaseField("color"), NotNull, DataType(MySqlDbType.VarChar, "7"), Column(Name:="color")> Public Property color As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `knowledge_vocabulary` (`vocabulary`, `description`, `add_time`, `color`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `knowledge_vocabulary` (`id`, `vocabulary`, `description`, `add_time`, `color`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `knowledge_vocabulary` (`vocabulary`, `description`, `add_time`, `color`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `knowledge_vocabulary` (`id`, `vocabulary`, `description`, `add_time`, `color`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `knowledge_vocabulary` WHERE `id` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `knowledge_vocabulary` SET `id`='{0}', `vocabulary`='{1}', `description`='{2}', `add_time`='{3}', `color`='{4}' WHERE `id` = '{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `knowledge_vocabulary` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `knowledge_vocabulary` (`id`, `vocabulary`, `description`, `add_time`, `color`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, vocabulary, description, MySqlScript.ToMySqlDateTimeString(add_time), color)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `knowledge_vocabulary` (`id`, `vocabulary`, `description`, `add_time`, `color`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, id, vocabulary, description, MySqlScript.ToMySqlDateTimeString(add_time), color)
        Else
        Return String.Format(INSERT_SQL, vocabulary, description, MySqlScript.ToMySqlDateTimeString(add_time), color)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{id}', '{vocabulary}', '{description}', '{add_time}', '{color}')"
        Else
            Return $"('{vocabulary}', '{description}', '{add_time}', '{color}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `knowledge_vocabulary` (`id`, `vocabulary`, `description`, `add_time`, `color`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, vocabulary, description, MySqlScript.ToMySqlDateTimeString(add_time), color)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `knowledge_vocabulary` (`id`, `vocabulary`, `description`, `add_time`, `color`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, id, vocabulary, description, MySqlScript.ToMySqlDateTimeString(add_time), color)
        Else
        Return String.Format(REPLACE_SQL, vocabulary, description, MySqlScript.ToMySqlDateTimeString(add_time), color)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `knowledge_vocabulary` SET `id`='{0}', `vocabulary`='{1}', `description`='{2}', `add_time`='{3}', `color`='{4}' WHERE `id` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, vocabulary, description, MySqlScript.ToMySqlDateTimeString(add_time), color, id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As knowledge_vocabulary
                         Return DirectCast(MyClass.MemberwiseClone, knowledge_vocabulary)
                     End Function
End Class


End Namespace
