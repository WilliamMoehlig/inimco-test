import './bootstrap.min.css';
import './App.css';
import './'
import PersonComponent from './Components/PersonComponent';


function App() {
  return (
    <div className="App container" style={{ marginTop: '50px' }}>
      <div className="row">
        <h1>Dev Test Inimco</h1>
        <PersonComponent />
      </div>
    </div>
  );
}

export default App;
