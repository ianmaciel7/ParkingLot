import React, { useEffect, useState } from "react";
import TextField from "@material-ui/core/TextField";
import { makeStyles } from "@material-ui/core/styles";
import InputLabel from "@material-ui/core/InputLabel";
import MenuItem from "@material-ui/core/MenuItem";
import FormHelperText from "@material-ui/core/FormHelperText";
import FormControl from "@material-ui/core/FormControl";
import Select from "@material-ui/core/Select";
import Button from "@material-ui/core/Button";
import Paper from "@material-ui/core/Paper";
import MuiAlert from "@material-ui/lab/Alert";
import { shadows } from "@material-ui/system";

import API from "../../services/API";
import SnackbarCode from "../SnackbarCode";

const useStyles = makeStyles((theme) => ({
  root: {
    "& .MuiTextField-root": {
      margin: theme.spacing(1),
      width: "25ch",
    },
  },
  btn_register: {
    margin: "8px",
  },
}));

const vehicleTypeEnum = [
  {
    value: "CAR",
    label: "Carro",
  },
  {
    value: "MOTORCYCLE",
    label: "Moto",
  },
];

const FormRegisterTicket = () => {
  const [open, setOpen] = useState(false);
  const [code, setCode] = useState(0);
  const [vehicleType, setVehicleType] = useState("CAR");
  const [timeOfArrival, setTimeOfArrival] = useState(
    new Date().toLocaleString("pt-BR")
  );

  const classes = useStyles();

  function handleSubmit(e) {
    e.preventDefault();
    API.postTicket({
      vehicleType: e.target.vehicleType.value,
      timeOfArrival: new Date().toISOString(),
    }).then((response) => {
      setCode(response);
      setOpen(true);
    });
  }

  useEffect(() => {
    setInterval(() => {
      return setTimeOfArrival(new Date().toLocaleString("pt-BR"));
    }, [1000]);
  }, [timeOfArrival]);

  return (
    <>
      <SnackbarCode
        code={code}
        setCode={setCode}
        open={open}
        setOpen={setOpen}
      />
      <form
        className={classes.root}
        noValidate
        onSubmit={(e) => {
          handleSubmit(e);
        }}
      >
        <div>
          <TextField
            id="input-vehicleType"
            name="vehicleType"
            select
            label="Selecione"
            helperText="Selecione o tipo de veiculo"
            value={vehicleType}
            onChange={(event) => setVehicleType(event.target.value)}
            variant="outlined"
          >
            {vehicleTypeEnum.map((option) => (
              <MenuItem key={option.value} value={option.value}>
                {option.label}
              </MenuItem>
            ))}
          </TextField>
        </div>
        <div>
          <TextField
            disabled
            id="filled-disabled"
            name="timeOfArrival"
            label="Hora Atual"
            value={timeOfArrival}
            variant="filled"
          />
        </div>
        <div>
          <Button
            className={classes.btn_register}
            variant="contained"
            size="large"
            color="primary"
            type="submit"
          >
            Registrar
          </Button>
        </div>
      </form>
    </>
  );
};

export default FormRegisterTicket;
