﻿Imports System.Windows.Forms

Public Class Principal
    Dim atualWindowState As FormWindowState = FormWindowState.Maximized
    Dim LateralEsquerda As New Form With {
            .ControlBox = False,
            .FormBorderStyle = FormBorderStyle.None,
    .StartPosition = FormStartPosition.Manual
        }
    Dim WithEvents FormCentral As New Form With {
            .ControlBox = False,
            .FormBorderStyle = FormBorderStyle.None,
            .StartPosition = FormStartPosition.Manual,
            .AutoScroll = True
        }
    Dim LateralDireita As New Form With {
            .ControlBox = False,
            .FormBorderStyle = FormBorderStyle.None,
            .StartPosition = FormStartPosition.Manual
        }
    Dim redimensionando = New Panel
    Dim splitconteiner = New SplitContainer

    Private Sub Principal_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        LateralEsquerda.Height = Me.ClientSize.Height - (MenuStrip.Height + StatusStrip.Height) - 4
        LateralDireita.Height = Me.ClientSize.Height - (MenuStrip.Height + StatusStrip.Height) - 4
        FormCentral.Height = Me.ClientSize.Height - (MenuStrip.Height + StatusStrip.Height) - 4

        'LateralEsquerda.Width = 200
        'LateralDireita.Width = 200
        FormCentral.Width = Me.ClientSize.Width - (LateralDireita.Width + LateralEsquerda.Width) - 4

        LateralEsquerda.Location = New Point(0, 0)
        FormCentral.Location = New Point(LateralEsquerda.Width, 0)
        LateralDireita.Location = New Point(LateralEsquerda.Width + FormCentral.Width, 0)
    End Sub
    Private Sub Principal_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        LateralEsquerda.hide()
        FormCentral.hide()
        LateralDireita.hide()
        Me.Controls.Add(redimensionando)
    End Sub

    Private Sub Principal_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        LateralEsquerda.show()
        FormCentral.show()
        LateralDireita.show()
        Me.Controls.Remove(redimensionando)
    End Sub
    Private Sub FormCentral_SizeChanged(sender As Object, e As EventArgs) Handles FormCentral.SizeChanged

    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If usuario.usuario_logado = False Then
            Dim Login = New Login
            Login.ShowDialog()
        End If
        lbl_usuarioLogado.Text = "Logado como: " & usuario.usuario_user


        Dim mi_afazer As New ToolStripMenuItem("Afazer")
        AddHandler mi_afazer.Click, AddressOf mi_afazer_Click
        Me.MenuStrip.Items.Add(mi_afazer)

        Dim mi_eventos As New ToolStripMenuItem("Eventos")
        AddHandler mi_eventos.Click, AddressOf mi_eventos_Click
        Me.MenuStrip.Items.Add(mi_eventos)

        Dim mi_dispositivos As New ToolStripMenuItem("Dispositivos")
        Dim si_computador As New ToolStripMenuItem("Computador")
        mi_dispositivos.DropDownItems.Add(si_computador)
        AddHandler si_computador.Click, AddressOf si_computador_Click
        Dim si_notebook As New ToolStripMenuItem("Notebook")
        mi_dispositivos.DropDownItems.Add(si_notebook)
        AddHandler si_notebook.Click, AddressOf si_notebook_Click
        Dim si_chromebook As New ToolStripMenuItem("Chromebook")
        mi_dispositivos.DropDownItems.Add(si_chromebook)
        AddHandler si_chromebook.Click, AddressOf si_chromebook_Click
        Dim si_tablet As New ToolStripMenuItem("Tablet")
        mi_dispositivos.DropDownItems.Add(si_tablet)
        AddHandler si_tablet.Click, AddressOf si_tablet_Click
        Dim si_celular As New ToolStripMenuItem("Celular")
        mi_dispositivos.DropDownItems.Add(si_celular)
        AddHandler si_celular.Click, AddressOf si_celular_Click
        Me.MenuStrip.Items.Add(mi_dispositivos)

        Dim mi_impressora As New ToolStripMenuItem("Impressora")
        AddHandler mi_impressora.Click, AddressOf mi_impressora_Click
        Me.MenuStrip.Items.Add(mi_impressora)
        Dim mi_nobreak As New ToolStripMenuItem("Nobreak")
        AddHandler mi_nobreak.Click, AddressOf mi_nobreak_Click
        Me.MenuStrip.Items.Add(mi_nobreak)
        Dim mi_projetor As New ToolStripMenuItem("Projetor")
        AddHandler mi_projetor.Click, AddressOf mi_projetor_Click
        Me.MenuStrip.Items.Add(mi_projetor)
        Dim mi_camera As New ToolStripMenuItem("Camera")
        AddHandler mi_camera.Click, AddressOf mi_camera_Click
        Me.MenuStrip.Items.Add(mi_camera)

        Dim mi_contas As New ToolStripMenuItem("Contas")
        Dim si_email As New ToolStripMenuItem("E-mail")
        mi_contas.DropDownItems.Add(si_email)
        AddHandler si_email.Click, AddressOf si_email_Click
        Dim si_skype As New ToolStripMenuItem("Skype")
        mi_contas.DropDownItems.Add(si_skype)
        AddHandler si_skype.Click, AddressOf si_skype_Click
        Me.MenuStrip.Items.Add(mi_contas)

        Dim mi_pessoas As New ToolStripMenuItem("Pessoas")
        AddHandler mi_pessoas.Click, AddressOf mi_pessoas_Click
        Me.MenuStrip.Items.Add(mi_pessoas)
        Dim mi_estoque As New ToolStripMenuItem("Estoque")
        AddHandler mi_estoque.Click, AddressOf mi_estoque_Click
        Me.MenuStrip.Items.Add(mi_estoque)
        Dim mi_software As New ToolStripMenuItem("Sofware")
        AddHandler mi_software.Click, AddressOf mi_software_Click
        Me.MenuStrip.Items.Add(mi_software)

        Dim mi_desconectar As New ToolStripMenuItem("Desconectar")
        AddHandler mi_desconectar.Click, AddressOf mi_desconectar_Click
        Me.MenuStrip.Items.Add(mi_desconectar)

        redimensionando.BackgroundImage = Image.FromFile("C:\Users\edward.huayta\source\repos\controle\util\rezise-icon2.png")
        redimensionando.BackgroundImageLayout = ImageLayout.Center
        redimensionando.Dock = DockStyle.Fill

        LateralEsquerda.Height = Me.ClientSize.Height - (MenuStrip.Height + StatusStrip.Height) - 4
        LateralDireita.Height = Me.ClientSize.Height - (MenuStrip.Height + StatusStrip.Height) - 4
        FormCentral.Height = Me.ClientSize.Height - (MenuStrip.Height + StatusStrip.Height) - 4

        LateralEsquerda.Width = 200
        LateralDireita.Width = 200
        FormCentral.Width = Me.ClientSize.Width - (LateralDireita.Width + LateralEsquerda.Width) - 4

        LateralEsquerda.Location = New Point(0, 0)
        FormCentral.Location = New Point(LateralEsquerda.Width, 0)
        LateralDireita.Location = New Point(LateralEsquerda.Width + FormCentral.Width, 0)

        LateralEsquerda.BackColor = New Color().FromArgb(255, 50, 50, 50)
        LateralDireita.BackColor = New Color().FromArgb(255, 100, 100, 100)
        FormCentral.BackColor = New Color().FromArgb(255, 150, 150, 150)

        LateralEsquerda.mdiparent = Me
        FormCentral.mdiparent = Me
        LateralDireita.mdiparent = Me
        LateralEsquerda.Show()
        FormCentral.Show()
        LateralDireita.Show()

        splitconteiner.orientation = System.Windows.Forms.Orientation.Horizontal
        Dim txt_teste As New TextBox()
        splitconteiner.dock = DockStyle.Fill
        splitconteiner.Panel2.controls.add(txt_teste)
        LateralEsquerda.Controls.Add(splitconteiner)

        'MsgBox(Me.ClientSize.Height & "\n" & Me.Height & "\n" & LateralEsquerda.Height)
        'MsgBox(MenuStrip.Height & "\n" & StatusStrip.Height & "\n")
    End Sub


    Private Sub mi_afazer_Click()
        'Dim verAfazer = New listarAfazer(FormCentral)
        Dim verAfazer = New DetalhesAfazer(1016)
        verAfazer.Show()

        'If (Application.OpenForms.OfType(Of listarAfazer).Any()) Then
        '    Application.OpenForms.OfType(Of listarAfazer).First().BringToFront()
        'Else
        '    'Dim verAfazer = New listarAfazer
        '    listarAfazer.MdiParent = Me
        '    'listarAfazer.Dock = DockStyle.Fill
        '    listarAfazer.ShowIcon = False
        '    'listarAfazer.MaximizeBox = False

        '    listarAfazer.Show()
        '    'listarAfazer.WindowState = FormWindowState.Maximized
        'End If
    End Sub
    Private Sub mi_eventos_Click()
        MsgBox("mi_eventos")
    End Sub
    Private Sub si_computador_Click()
        MsgBox("si_computador")
    End Sub
    Private Sub si_notebook_Click()
        MsgBox("si_notebook")
    End Sub
    Private Sub si_chromebook_Click()
        MsgBox("si_chromebook")
    End Sub
    Private Sub si_tablet_Click()
        MsgBox("si_tablet")
    End Sub
    Private Sub si_celular_Click()
        MsgBox("si_celular")
    End Sub
    Private Sub mi_impressora_Click()
        'If (Application.OpenForms.OfType(Of ListarImpressora).Any()) Then
        '    Application.OpenForms.OfType(Of ListarImpressora).First().BringToFront()
        'Else
        '    'Dim listarImpressora = New ListarImpressora
        '    ListarImpressora.MdiParent = Me
        '    ListarImpressora.Dock = DockStyle.Fill
        '    ListarImpressora.ShowIcon = False
        '    ListarImpressora.MaximizeBox = False
        '    ListarImpressora.Show()
        'End If
    End Sub
    Private Sub mi_nobreak_Click()
        MsgBox("mi_nobreak")
    End Sub
    Private Sub mi_projetor_Click()
        MsgBox("mi_projetor")
    End Sub
    Private Sub mi_camera_Click()
        MsgBox("mi_camera")
    End Sub
    Private Sub si_email_Click()
        MsgBox("mi_email")
    End Sub
    Private Sub si_skype_Click()
        MsgBox("mi_skype")
    End Sub
    Private Sub mi_pessoas_Click()
        MsgBox("mi_pessoas")
    End Sub
    Private Sub mi_estoque_Click()
        MsgBox("mi_estoque")
    End Sub
    Private Sub mi_software_Click()
        MsgBox("mi_software")
    End Sub
    Private Sub mi_desconectar_Click()
        usuario.usuario_logado = False
        Application.Restart()
    End Sub


End Class