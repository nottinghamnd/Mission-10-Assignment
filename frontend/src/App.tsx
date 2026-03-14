import './App.css'
import BowlerList from './BowlerList'

function Header() {
  return (
    <>
    <h1>Welcome to the Bowling League Roster!</h1>
    <br />
    <p>Below is a list of all the bowlers in our program, their addresses, zip codes, and phone numbers! Do with this information what you will!</p>
    </>
  )
}

function App() {

  return (
    <>
      <Header></Header>
      <BowlerList></BowlerList>
    </>
  )
}

export default App
