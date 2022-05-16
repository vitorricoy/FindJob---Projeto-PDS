import React from 'react';
import './App.css';
import { Login } from './components/Login/Login';
import { Register } from './components/Register/Register';
import { Home } from './components/Home/Home';
import { CreateJob } from './components/CreateJob/CreateJob';
import { JobsList } from './components/JobsList/JobsList';
import { FreelancerJobView } from './components/FreelancerJobView/FreelancerJobView';
import { Chat } from './components/Chat/Chat';
import { ClientJobView } from './components/ClientJobView/ClientJobView';

function App() {
  return (
    <div>
      <Register />
    </div>
  );
}

export default App;
