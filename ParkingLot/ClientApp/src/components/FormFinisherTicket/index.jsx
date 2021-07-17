import React, { useEffect, useState } from "react";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import API from "../../services/API";
import { makeStyles } from "@material-ui/core/styles";
import SnackbarCode from "../SnackbarCode";

const useStyles = makeStyles((theme) => ({
  root: {
    "& .MuiTextField-root": {
      margin: theme.spacing(1),
      width: "25ch",
    },
  },
  btn_finisher: {
    margin: "8px",
  },
}));

const FormFinisherTicket = () => {
  const [open, setOpen] = React.useState(false);
  const [code, setCode] = React.useState(0);
  const classes = useStyles();

  const [id, setId] = useState(0);

  async function handleSubmit(e) {
    e.preventDefault();
    const id = e.target.id.value;
    
    const codePatchTicket = await API.patchTicket(id);
    const codePatchParkingSpace = await API.patchParkingSpace(id);
   
    if (codePatchTicket == 200 && codePatchParkingSpace == 200) {
      setCode(200);
      setOpen(true);
    } else if (codePatchParkingSpace == 404 || codePatchTicket == 404) {
      setCode(404);
      setOpen(true);
    } else {
      setCode(400);
      setOpen(true);
    }
  }

  return (
    <>
      <SnackbarCode
        code={code}
        setCode={setCode}
        open={open}
        setOpen={setOpen}
      />
      <form className={classes.root} noValidate onSubmit={handleSubmit}>
        <div>
          <TextField
            required
            id="input-id"
            name="id"
            label="Código"
            type="number"
            value={id}
            variant="outlined"
            onInput={(e) => setId(e.target.value)}
            InputLabelProps={{
              shrink: true,
            }}
          />
        </div>
        <div>
          <Button
            className={classes.btn_finisher}
            variant="contained"
            size="large"
            color="primary"
            type="submit"
          >
            Finalizar Ticket
          </Button>
        </div>
      </form>
    </>
  );
};

export default FormFinisherTicket;
