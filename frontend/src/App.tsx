import React from 'react';
import './App.css';
import { Login } from './components/Login/Login';
import { Register } from './components/Register/Register';
import { Home } from './components/Home/Home';
import { CreateJob } from './components/CreateJob/CreateJob';
import { JobsList } from './components/JobsList/JobsList';

function App() {
  return (
    <div>
      <JobsList/>
    </div>
  );
}

export default App;
