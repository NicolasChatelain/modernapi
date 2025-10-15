import './App.css'

function App() {

  const toggleTheme = () => {
    const currentTheme = window.__theme;
    const newTheme = currentTheme === "dark" ? "light" : "dark";
    window.__setPreferredTheme(newTheme);
  };

  return (
    <>
      <p>Hello world!</p>
      <button onClick={toggleTheme}>Theme</button>
    </>
  )
}

export default App
