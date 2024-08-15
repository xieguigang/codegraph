REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @8/14/2024 9:31:42 PM


Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.SchemaMaps
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace pubmed

''' <summary>
''' ```SQL
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("mesh", Database:="pubmed", SchemaSQL:="
CREATE TABLE IF NOT EXISTS `mesh` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `term` VARCHAR(255) NOT NULL COMMENT 'the pubmed mesh term',
  `db_xref` VARCHAR(64) NULL COMMENT 'the external database reference id of current mesh term',
  `db_name` VARCHAR(45) NULL COMMENT 'the  name of the external database',
  `description` LONGTEXT NULL COMMENT 'the description text of current mesh term',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;")>
Public Class mesh: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.UInt32, "11"), Column(Name:="id"), XmlAttribute> Public Property id As UInteger
''' <summary>
''' the pubmed mesh term
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("term"), NotNull, DataType(MySqlDbType.VarChar, "255"), Column(Name:="term")> Public Property term As String
''' <summary>
''' the external database reference id of current mesh term
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("db_xref"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="db_xref")> Public Property db_xref As String
''' <summary>
''' the  name of the external database
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("db_name"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="db_name")> Public Property db_name As String
''' <summary>
''' the description text of current mesh term
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("description"), DataType(MySqlDbType.Text), Column(Name:="description")> Public Property description As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `mesh` (`term`, `db_xref`, `db_name`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `mesh` (`id`, `term`, `db_xref`, `db_name`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `mesh` (`term`, `db_xref`, `db_name`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `mesh` (`id`, `term`, `db_xref`, `db_name`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `mesh` WHERE `id` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `mesh` SET `id`='{0}', `term`='{1}', `db_xref`='{2}', `db_name`='{3}', `description`='{4}' WHERE `id` = '{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `mesh` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `mesh` (`id`, `term`, `db_xref`, `db_name`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, term, db_xref, db_name, description)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `mesh` (`id`, `term`, `db_xref`, `db_name`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, id, term, db_xref, db_name, description)
        Else
        Return String.Format(INSERT_SQL, term, db_xref, db_name, description)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{id}', '{term}', '{db_xref}', '{db_name}', '{description}')"
        Else
            Return $"('{term}', '{db_xref}', '{db_name}', '{description}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `mesh` (`id`, `term`, `db_xref`, `db_name`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, term, db_xref, db_name, description)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `mesh` (`id`, `term`, `db_xref`, `db_name`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, id, term, db_xref, db_name, description)
        Else
        Return String.Format(REPLACE_SQL, term, db_xref, db_name, description)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `mesh` SET `id`='{0}', `term`='{1}', `db_xref`='{2}', `db_name`='{3}', `description`='{4}' WHERE `id` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, term, db_xref, db_name, description, id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As mesh
                         Return DirectCast(MyClass.MemberwiseClone, mesh)
                     End Function
End Class


End Namespace
