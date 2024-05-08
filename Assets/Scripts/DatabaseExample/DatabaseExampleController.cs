using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DatabaseExampleController : MonoBehaviour
{
    [SerializeField] DatabaseCommands dbCommands;

    [SerializeField] TMP_Dropdown dropdownPlayersNames;
    [SerializeField] TMP_InputField nameInput;

    private async Task Start()
    {
        await UpdateDropdown();
    }

    public void PopulateDropdown(List<Player> playerList)
    {
        var selectedOption = new TMP_Dropdown.OptionData();

        //Verifica se a dropdown tem algum item para pegar o que estava selecionado antes da atualização
        if (dropdownPlayersNames.options.Count > 0)
            selectedOption = dropdownPlayersNames.options[dropdownPlayersNames.value];

        //Limpa todas os itens
        dropdownPlayersNames.ClearOptions();

        //Adiciona cada item
        foreach (var element in playerList)
            dropdownPlayersNames.options.Add(new TMP_Dropdown.OptionData(element.playerName));

        //Determina qual estava selecionado antes da atualização
        var dropdownValue = GetDropdownValueByOptionText(selectedOption.text);

        //Seta o valor para deixar o item selecionado mesmo após a atualização
        if (selectedOption.text != null && selectedOption.text != string.Empty && dropdownValue != -1)
            dropdownPlayersNames.value = dropdownValue;

        //Refresh no aspecto visual da dropdown
        dropdownPlayersNames.RefreshShownValue();
    }

    private int GetDropdownValueByOptionText(string optionText)
    {
        for (int i = 0; i < dropdownPlayersNames.options.Count; i++)
        {
            if (dropdownPlayersNames.options[i].text == optionText)
                return i;
        }
        return -1; // Retorna -1 se não encontrar correspondência
    }

    public async void CreatePlayer()
    {
        if (nameInput.text != null && nameInput.text != string.Empty)
        {
            await dbCommands.CreatePlayer(nameInput.text);
            nameInput.text = string.Empty;

            await UpdateDropdown();
        }
    }

    private async Task UpdateDropdown()
    {
        var players = await dbCommands.GetAllPlayers();
        PopulateDropdown(players);
    }
}
