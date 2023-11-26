REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @11/26/2023 11:30:39 AM


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
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("knowledge_cache", Database:="graphQL", SchemaSQL:="
CREATE TABLE IF NOT EXISTS `knowledge_cache` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `seed_id` INT UNSIGNED NOT NULL,
  `knowledge` LONGTEXT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;
")>
Public Class knowledge_cache: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.UInt32, "11"), Column(Name:="id"), XmlAttribute> Public Property id As UInteger
    <DatabaseField("seed_id"), NotNull, DataType(MySqlDbType.UInt32, "11"), Column(Name:="seed_id")> Public Property seed_id As UInteger
    <DatabaseField("knowledge"), NotNull, DataType(MySqlDbType.Text), Column(Name:="knowledge")> Public Property knowledge As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `knowledge_cache` (`seed_id`, `knowledge`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `knowledge_cache` (`id`, `seed_id`, `knowledge`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `knowledge_cache` (`seed_id`, `knowledge`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `knowledge_cache` (`id`, `seed_id`, `knowledge`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `knowledge_cache` WHERE `id` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `knowledge_cache` SET `id`='{0}', `seed_id`='{1}', `knowledge`='{2}' WHERE `id` = '{3}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `knowledge_cache` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `knowledge_cache` (`id`, `seed_id`, `knowledge`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, seed_id, knowledge)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `knowledge_cache` (`id`, `seed_id`, `knowledge`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, id, seed_id, knowledge)
        Else
        Return String.Format(INSERT_SQL, seed_id, knowledge)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{id}', '{seed_id}', '{knowledge}')"
        Else
            Return $"('{seed_id}', '{knowledge}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `knowledge_cache` (`id`, `seed_id`, `knowledge`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, seed_id, knowledge)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `knowledge_cache` (`id`, `seed_id`, `knowledge`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, id, seed_id, knowledge)
        Else
        Return String.Format(REPLACE_SQL, seed_id, knowledge)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `knowledge_cache` SET `id`='{0}', `seed_id`='{1}', `knowledge`='{2}' WHERE `id` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, seed_id, knowledge, id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As knowledge_cache
                         Return DirectCast(MyClass.MemberwiseClone, knowledge_cache)
                     End Function
End Class


End Namespace
