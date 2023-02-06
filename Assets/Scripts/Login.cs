using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField emailInputField;
    public InputField passwordInputField;
    public Button loginButton;
    public Text errorText;
    public GameObject welcomeText;
    public Button logoutButton;
    public bool isLoginned;

    private void Awake()
    {
        passwordInputField.contentType = InputField.ContentType.Password;


        //önceden kullanıcının giriş yapıp yapmadığını playerprefsle tuttum.(hem email ile şifreyi string ile hem de bool atadım onu 1 veya 0 değerini döndürdüm)
        if (PlayerPrefs.HasKey("email")&& (PlayerPrefs.GetInt("isLoginned") == 1))
        {
            string email = PlayerPrefs.GetString("email");
            string password = PlayerPrefs.GetString("password");



            //aşağıda da database de hangi kullanıcı adı ve şifreler varsa onları veya koyup ekleyebilirim. ya da liste yapıp listede verip tutup çekerim.
            if (email == "kullanici@mail.com" && password == "sifre"||email == "kullanici2@mail.com" && password == "sifre2")
            {
                Debug.Log("Giriş Başarılı");
                errorText.text = "";
                emailInputField.gameObject.SetActive(false);
                passwordInputField.gameObject.SetActive(false);
                welcomeText.GetComponent<Text>().text = "Merhaba " + email;
                welcomeText.SetActive(true);
                logoutButton.gameObject.SetActive(true);
                loginButton.interactable = false;
                loginButton.gameObject.SetActive(false);
                isLoginned = true;
            }
        }
    }
    private void Start()
    {
        loginButton.onClick.AddListener(HandleLogin);
        logoutButton.onClick.AddListener(HandleLogout);
        //burda isLoginned false dönerse yani yanlış yazarsa welcome veya logout butonu hic cıkmasın diye returnladım.
        //bişey için daha returnlamıştım da unuttum.
        if (isLoginned)
        {
            return;
        }
        welcomeText.SetActive(false);
        logoutButton.gameObject.SetActive(false);
    }

    private void HandleLogin()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;


        //aşağıda database'e eklemek istediğim hesapları veya parametresi kullanarak ya da listede tutup çekerek eklerim.
        if (email == "kullanici@mail.com" && password == "sifre"||email == "kullanici2@mail.com" && password == "sifre2")
        {
            isLoginned = true;
            PlayerPrefs.SetInt("isLoginned", isLoginned ? 1 : 0);
            Debug.Log("Giriş Başarılı");
            errorText.text = "";
            emailInputField.gameObject.SetActive(false);
            passwordInputField.gameObject.SetActive(false);
            welcomeText.GetComponent<Text>().text = "Merhaba " + email;
            welcomeText.SetActive(true);
            logoutButton.gameObject.SetActive(true);
            loginButton.interactable = false;
            loginButton.gameObject.SetActive(false);
            PlayerPrefs.SetString("email", email);
            PlayerPrefs.SetString("password", password);

        }
        else
        {

            Debug.Log("Giriş Başarısız. Şifre Hatalı");
            errorText.text = "Şifre Hatalı!";
            welcomeText.SetActive(false);
            logoutButton.gameObject.SetActive(false);
            isLoginned = false;
        }
    }

    public void HandleLogout()
    {
        isLoginned = false;
        PlayerPrefs.SetInt("isLoginned", isLoginned ? 1 : 0);
        welcomeText.SetActive(false);
        logoutButton.gameObject.SetActive(false);
        emailInputField.gameObject.SetActive(true);
        passwordInputField.gameObject.SetActive(true);
        emailInputField.text = "";
        passwordInputField.text = "";
        loginButton.interactable = true;
        loginButton.gameObject.SetActive(true);
    }
}

