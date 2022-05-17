import React from 'react';
import './App.css';
import { Route, BrowserRouter, Routes } from 'react-router-dom';
import { Login } from './components/Login/Login';
import { Register } from './components/Register/Register';
import { Home } from './components/Home/Home';
import { CreateJob } from './components/CreateJob/CreateJob';
import { JobsList } from './components/JobsList/JobsList';
import { FreelancerJobView } from './components/FreelancerJobView/FreelancerJobView';
import { ClientJobView } from './components/ClientJobView/ClientJobView';
import { Chat } from './components/Chat/Chat';

function App() {
  return (
    <div className="wrapper">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Login/>} />
          <Route path="/register" element={<Register/>} />
          <Route path="/home" element={<Home/>} />
          <Route path="/create-job" element={<CreateJob/>} />
          <Route path="/jobs-list/:type" element={<JobsList/>} />
          <Route path="/freelancer-job-view" element={<FreelancerJobView/>} />
          <Route path="/client-job-view" element={<ClientJobView/>} />
          <Route path="/chat" element={<Chat/>} />
        </Routes>
       </BrowserRouter>
    </div>
  );
}

export default App;
