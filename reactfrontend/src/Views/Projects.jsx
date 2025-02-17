import React, { useState, useEffect } from "react"

const Projects = () => {

  const [project, setProject] = useState([])

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
      {
        project.length > 0 && project.map((p) => (
            <p key={p.id}>Project name: {p.name}<br />
            Customer name: {p.customerName}</p>
        ))
      }
    </>
  )
}

export default Projects