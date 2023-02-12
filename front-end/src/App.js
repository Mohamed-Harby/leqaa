// import logo from './logo.svg';
import './App.css';
import { RouterConfig } from './Navigation/Config';
import { RouterProvider } from 'react-router-dom';
import { ProvideAuth } from './Custom/useAuth';

function App() {
  return (
    <div className="App">
      <ProvideAuth>
        <RouterProvider router={RouterConfig} />
      </ProvideAuth>
    </div>
  );
}

export default App;
