import { Button } from "./components/ui/button"

function App() {

  const toggleTheme = () => {
    const currentTheme = window.__theme;
    const newTheme = currentTheme === "dark" ? "light" : "dark";
    window.__setPreferredTheme(newTheme);
  };

  return (
    <>
      <p>Hello world!</p>
      <div>
        <Button onClick={toggleTheme}>Theme</Button>
      </div>
    </>
  )
}

export default App
