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
  
  return (
    <>
      <Nav />
      <main>
        <div className="projects">
          <p>Project Name</p>
          <p>Customer Name</p>
          <p>Employee Name</p>
          <p>Service Title</p>
          <div className="buttons">
            <p>Actions</p>
          </div>
          
          {projects.length > 0 && projects.map((project) => (
            <Project key={project.id} p={project} />
          ))}
        </div>
      </main>
    </>
  )
}

export default Projects