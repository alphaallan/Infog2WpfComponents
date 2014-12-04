Infog2WpfComponents
=======================================================================================================================
Componentes para uso com Wpf

===================================================== Componentes =====================================================
EnumRadioButton -> RadioButton Especializado para interagir com tipos enum, Código copiado do CodeProject.
	Link do Artigo : http://www.codeproject.com/Articles/61725/WPF-radio-buttons-and-enumeration-values
	
	Propriedades Adicionais:
		EnumBiding -> Propriedade tipo enum que será manipulada 
		EnumValue -> Valor a ser atribuído a propriedade
 

MyButton -> Botão com estilo do windows forms por padrão e ícone opcional
	Propriedades Adicionais:
		ConerRadius -> Raio das bordas
		NormalBrush -> cor de fundo padrão
		NormalBorderBrush -> cor da borda padrão
		PressedBrush -> cor do fundo quando pressionado
		PressedBorderBrush -> cor da borda quando pressionado
		MouseOverBrush -> cor do fundo quando sob o mouse
		Icon -> Caminho para uma imagem opcional que fica a esquerda do texto do botão (auto dimensionada)
		IconSize -> Tamanho opcional do ícone

MyComboBox -> Combobox com o estilo padrão do windows forms
	Propriedades Adicionais:
		AutoSizeFont -> booleano que ativa o dimensionamento automático da fonte de acordo com a altura do controle
	
	Comportamentos Adicionais:
		Dimensiona a altura da ComboBox automaticamente de acordo com a fonte por padrão (desativado caso AutoSize 
			esteja ativado ou a altura esteja atribuída) 
		
MyDataGrid -> DataGrid com alguns valores padrão alterados
	Propriedades -> Valores:
		SelectionMode -> Single
		SelectionUnit -> FullRow
		IsReadOnly -> True
		MinHeight -> 125
		MinWidth -> 125
		FontSize -> 14

MyDatePicker -> DatePicker com algumas alterações de comportamento e aparência
	Propriedades Adicionais:
		AutoSizeFont -> booleano que ativa o dimensionamento automático da fonte de acordo com a altura do controle
		ConerRadius -> Raio das bordas
		NoFocusColor -> Cor do fundo quando sem foco
		HaveFocusColor -> Cor do fundo quando em foco
	
	Comportamentos Adicionais:
		Dimensiona a altura da ComboBox automaticamente de acordo com a fonte por padrão (desativado caso AutoSize 
			esteja ativado ou a altura esteja atribuída)
		Muda a cor de fundo quando está focado
		Inicia com a data atual
		
MyImageButton -> Botão de imagem com um título abaixo opcional
	Propriedades Adicionais:
		Label -> Texto do título do botão
		LabelTemplate -> DataTemplate do título
		LabelAlignment -> Alinhamento horizontal do título
		Icon -> Imagem do botão
	
MyTextBox -> TextBox com vários adicionais
	Propriedades Adicionais:
		AutoSizeFont -> booleano que ativa o dimensionamento automático da fonte de acordo com a altura do controle
		Mask -> Define o tipo de texto a ser admitido 
			Any -> texto livre
			Integer -> Inteiro
			Decimal -> numero fracionário
			Money -> numero fracionário com duas casas decimais
		ConerRadius -> Raio das bordas
		HaveFocusColor -> Cor do fundo quando em foco
		Watermark -> marca d'água opcional
		WatermarkTemplate -> DataTemplate da marca d'água
		Prefix -> Prefixo opcional apresentado a esquerda do texto (apenas na interface de usuário)
		
	Comportamentos Adicionais:
		Dimensiona a altura da ComboBox automaticamente de acordo com a fonte por padrão (desativado caso AutoSize 
			esteja ativado ou a altura esteja atribuída)
		Muda a cor de fundo quando está focada
		Apresenta marca d'água (quando houver) e o prefixo (quando houver) se estiver sem foco 
		Filtragem de tipo de texto
		
	Funções Internas:
		MaskChangedCallback -> callback chamado quando a mascara de texto muda
		MyTextBoxPastingEventHandler -> Handler do evento do colagem de texto
		MyTextBox_PreviewTextInput -> Função de controle principal da filtragem
		IsSymbolValid -> Valida um simbolo que foi inserido
		ValidateValue -> valida um valor
		ValidateTextBox -> Valida o conteúdo da textbox
			
	
Tile -> botão estilizado semelhante as tiles do sistema metro do Windows
	Propriedades Adicionais:
		Label -> título da tile
		UpLabel -> Label Opcional fixada no canto direito superior
		LabelTemplete -> DataTemplate do título
		LabelAlignment -> Alinhamento Horizontal do título
		Icon -> Imagem central da tile	
		
Tile2 -> versão 2x1 da tile que adiciona uma área de notificação acessada pela propriedade Content
		
=======================================================================================================================

================================================= Classes auxiliares ==================================================
HeightToFontSizeConverter -> Conversor que dá o tamanho da fonte de acordo com a altura do controle

FocusAdvancement -> auxiliar que pode definir que a tecla "enter" (em um controle) passe para o próximo controle 
	Para usar adicionar FocusAdvancement.AdvancesByEnterKey="True" na declaração do controle no arquivo XAML
=======================================================================================================================