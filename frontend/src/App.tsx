import React from 'react';
import './App.css';
import { Login } from './components/Login/Login';
import { Register } from './components/Register/Register';
import { Home } from './components/Home/Home';
import { CreateJob } from './components/CreateJob/CreateJob';

function App() {
  return (
    <div>
      <CreateJob/>
    </div>
  );
}

export default App;
