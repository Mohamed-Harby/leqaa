import logo from './logo.svg';
import './App.css';
import { RouterConfig } from './Navigation/Config';
import { RouterProvider } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <RouterProvider router={RouterConfig} />
    </div>
  );
}

export default App;
