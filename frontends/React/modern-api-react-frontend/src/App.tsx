import {applyTheme, getTheme, switchTheme} from './theme/theme_switcher'
import { useEffect } from 'react'
import './App.css'

function App() {

  useEffect(() => {
    applyTheme(getTheme());
  }, []);

  return (
    <>
      <p>Hello world!</p>
      <button onClick={switchTheme}>Theme</button>
    </>
  )
}

export default App
