import React from "react"
import { useParams } from 'react-router-dom'
import ProjectUpdateForm from "../Components/ProjectUpdateForm"
import Nav from "../Components/Nav"

const ProjectEdit = () => {
  const { projectId } = useParams()

  return (
    <>
      <Nav />
      <main>
        <ProjectUpdateForm id={projectId}/>
      </main>
    </>
  )
}

export default ProjectEdit