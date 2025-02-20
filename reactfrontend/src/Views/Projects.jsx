import React, { useState, useEffect } from "react"
import Project from "../Components/Project"
import Nav from "../Components/Nav"

const Projects = () => {

  const [projects, setProject] = useState([])

  const fetchData = async () => {
    const res = await fetch("https://localhost:7123/api/project")
    const data = await res.json()
    setProject(data)
  }

  useEffect(() => {
    fetchData()
  }, [])

  const removeProject = (id) => {
    setProject(projects.filter(p => p.id !== id))
  }
  
  return (
    <>
      <Nav />
      <main>
        <div className="projects">
          <p className="top">Name</p>
          <p className="top">Status</p>
          <p className="top">Start date</p>
          <p className="top">End date</p>
          <p className="top">Description</p>
          <p className="top">Customer</p>
          <p className="top">Employee</p>
          <p className="top">Service</p>
          <p className="top">Price</p>
          <div className="buttons">
            <p className="top">Actions</p>
          </div>
          
          {projects.length > 0 && projects.map((project) => (
            <Project key={project.id} p={project} rp={removeProject} />
          ))}
        </div>
      </main>
    </>
  )
}

export default Projects