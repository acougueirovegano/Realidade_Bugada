using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void IniciarJogo()
    {
        // Garante que vai carregar a cena exata do jogo
        SceneManager.LoadScene("SampleScene"); 
    }

public void IniciarJogofacil()
    {
        // Garante que vai carregar a cena exata do jogo
        SceneManager.LoadScene("SampleScene1"); 
    }
    public void IniciarVoltar()
    {
        // Garante que vai carregar a cena exata do jogo
        SceneManager.LoadScene("Menu"); 
    }
}