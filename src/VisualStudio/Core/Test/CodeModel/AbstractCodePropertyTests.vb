' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Namespace Microsoft.VisualStudio.LanguageServices.UnitTests.CodeModel
    Public MustInherit Class AbstractCodePropertyTests
        Inherits AbstractCodeElementTests(Of EnvDTE80.CodeProperty2)

        Protected Overrides Function GetAccess(codeElement As EnvDTE80.CodeProperty2) As EnvDTE.vsCMAccess
            Return codeElement.Access
        End Function

        Protected Overrides Function GetComment(codeElement As EnvDTE80.CodeProperty2) As String
            Return codeElement.Comment
        End Function

        Protected Overrides Function GetDocComment(codeElement As EnvDTE80.CodeProperty2) As String
            Return codeElement.DocComment
        End Function

        Protected Overrides Function GetEndPointFunc(codeElement As EnvDTE80.CodeProperty2) As Func(Of EnvDTE.vsCMPart, EnvDTE.TextPoint)
            Return Function(part) codeElement.GetEndPoint(part)
        End Function

        Protected Overrides Function GetFullName(codeElement As EnvDTE80.CodeProperty2) As String
            Return codeElement.FullName
        End Function

        Protected Overrides Function GetIsDefault(codeElement As EnvDTE80.CodeProperty2) As Boolean
            Return codeElement.IsDefault
        End Function

        Protected Overrides Function GetIsDefaultSetter(codeElement As EnvDTE80.CodeProperty2) As Action(Of Boolean)
            Return Sub(value) codeElement.IsDefault = value
        End Function

        Protected Overrides Function GetKind(codeElement As EnvDTE80.CodeProperty2) As EnvDTE.vsCMElement
            Return codeElement.Kind
        End Function

        Protected Overrides Function GetName(codeElement As EnvDTE80.CodeProperty2) As String
            Return codeElement.Name
        End Function

        Protected Overrides Function GetNameSetter(codeElement As EnvDTE80.CodeProperty2) As Action(Of String)
            Return Sub(name) codeElement.Name = name
        End Function

        Protected Overrides Function GetOverrideKind(codeElement As EnvDTE80.CodeProperty2) As EnvDTE80.vsCMOverrideKind
            Return codeElement.OverrideKind
        End Function

        Protected Overrides Function GetOverrideKindSetter(codeElement As EnvDTE80.CodeProperty2) As Action(Of EnvDTE80.vsCMOverrideKind)
            Return Sub(value) codeElement.OverrideKind = value
        End Function

        Protected Overrides Function GetParent(codeElement As EnvDTE80.CodeProperty2) As Object
            Return codeElement.Parent
        End Function

        Protected Overrides Function GetPrototype(codeElement As EnvDTE80.CodeProperty2, flags As EnvDTE.vsCMPrototype) As String
            Return codeElement.Prototype(flags)
        End Function

        Protected Overrides Function GetReadWrite(codeElement As EnvDTE80.CodeProperty2) As EnvDTE80.vsCMPropertyKind
            Return codeElement.ReadWrite
        End Function

        Protected Overrides Function GetStartPointFunc(codeElement As EnvDTE80.CodeProperty2) As Func(Of EnvDTE.vsCMPart, EnvDTE.TextPoint)
            Return Function(part) codeElement.GetStartPoint(part)
        End Function

        Protected Overrides Function GetTypeProp(codeElement As EnvDTE80.CodeProperty2) As EnvDTE.CodeTypeRef
            Return codeElement.Type
        End Function

        Protected Overrides Function GetTypePropSetter(codeElement As EnvDTE80.CodeProperty2) As Action(Of EnvDTE.CodeTypeRef)
            Return Sub(value) codeElement.Type = value
        End Function

        Protected Overrides Function AddParameter(codeElement As EnvDTE80.CodeProperty2, data As ParameterData) As EnvDTE.CodeParameter
            Return codeElement.AddParameter(data.Name, data.Type, data.Position)
        End Function

        Protected Overrides Sub RemoveChild(codeElement As EnvDTE80.CodeProperty2, child As Object)
            codeElement.RemoveParameter(child)
        End Sub

        Protected Overridable Function AutoImplementedPropertyExtender_GetIsAutoImplemented(codeElement As EnvDTE80.CodeProperty2) As Boolean
            Throw New NotSupportedException
        End Function

        Protected Sub TestAutoImplementedPropertyExtender_IsAutoImplemented(code As XElement, expected As Boolean)
            Using state = CreateCodeModelTestState(GetWorkspaceDefinition(code))
                Dim codeElement = state.GetCodeElementAtCursor(Of EnvDTE80.CodeProperty2)()
                Assert.NotNull(codeElement)

                Assert.Equal(expected, AutoImplementedPropertyExtender_GetIsAutoImplemented(codeElement))
            End Using
        End Sub

        Protected Sub TestGetter(code As XElement, verifier As Action(Of EnvDTE.CodeFunction))
            Using state = CreateCodeModelTestState(GetWorkspaceDefinition(code))
                Dim codeElement = state.GetCodeElementAtCursor(Of EnvDTE80.CodeProperty2)()
                Assert.NotNull(codeElement)

                verifier(codeElement.Getter)
            End Using
        End Sub

        Protected Sub TestSetter(code As XElement, verifier As Action(Of EnvDTE.CodeFunction))
            Using state = CreateCodeModelTestState(GetWorkspaceDefinition(code))
                Dim codeElement = state.GetCodeElementAtCursor(Of EnvDTE80.CodeProperty2)()
                Assert.NotNull(codeElement)

                verifier(codeElement.Setter)
            End Using
        End Sub

    End Class
End Namespace
