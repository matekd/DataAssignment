import './App.css'

import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Projects from "./Views/Projects"
import ProjectEdit from "./Views/ProjectEdit"
import ProjectCreate from './Views/ProjectCreate'

function App() {

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Projects />} />
          <Route path="/project/:projectId" element={<ProjectEdit />} />
          <Route path="/project" element={<ProjectCreate />}/>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
