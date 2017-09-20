Imports System.Security.Cryptography
Public Class Encrypt

    Public Shared Function GenerateHash(ByVal pass As String) As String
        Dim HashAlgorithm As SHA1 = SHA1.Create() 'Hash algorithm declaration
        Dim c() As Byte 'Byte array to store the returned hashed data

        'Convert the input string to a byte array and compute the hash.
        c = HashAlgorithm.ComputeHash(Encoding.Default.GetBytes(pass))
        'String variable that will store the returned hashed string
        Dim hashedpass As String = ""

        Dim i As Integer
        'Loop through each byte of the hashed data and format each one as a hexadecimal string. 
        For i = 0 To (c.Length - 1)
            hashedpass &= c(i).ToString("x2")
        Next i
        'Return the hexadecimal string. 
        Return hashedpass
    End Function
End Class
