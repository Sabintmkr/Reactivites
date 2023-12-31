import { Fragment, useEffect, useState } from "react";
import axios from "axios";
import { Container, List } from "semantic-ui-react";
import { Activity } from "../models/activity";
import NavBar from "./NavBar";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);

  useEffect(() => {
    axios
      .get<Activity[]>("http://localhost:5000/api/activities")
      .then((response) => {
        setActivities(response.data);
      })
  }, [])

  function handleSelectActivity(id: string) {
    setSelectedActivity(activities.find(x => x.id === id));
  }

  function handleCancelActivity() {
    setSelectedActivity(undefined);
  }

  function handleFormOpen(id?: string) {
    id ? handleSelectActivity(id) : handleCancelActivity();
    setEditMode(true);
  }

  function handleFormClose(){
    setEditMode(false);
  }

  return (
    <Fragment> 
      {/* this can be either < /> or <Fragment> */}
      <NavBar openForm = {handleFormOpen} />
      <Container style={{ marginTop: "7em" }}>
      <ActivityDashboard 
      activities = {activities}
      selectedActivity = {selectedActivity}
      selectActivity = {handleSelectActivity}
      cancelSelectActivity = {handleCancelActivity}
      editMode = {editMode}
      openForm = {handleFormOpen}
      closeForm = {handleFormClose}
      />
      </Container>
    </Fragment>
  );
}

export default App;
