import React, { useEffect } from "react";
import Button from "@material-ui/core/Button";
import Snackbar from "@material-ui/core/Snackbar";
import MuiAlert from "@material-ui/lab/Alert";
import { makeStyles } from "@material-ui/core/styles";
import {
  MESSAGE_POST,
  MESSAGE_400,
  MESSAGE_507,
  MESSAGE_PATCH,
  MESSAGE_404
} from "../../helpers/message";

function Alert(props) {
  return <MuiAlert elevation={6} variant="filled" {...props} />;
}

const useStyles = makeStyles((theme) => ({
  root: {
    width: "100%",
    "& > * + *": {
      marginTop: theme.spacing(2),
    },
  },
}));

export default function SnackbarCode(props) {
  const classes = useStyles();
  const open = props.open;
  const setOpen = props.setOpen;
  const code = props.code;
  const setCode = props.setCode;
  const [message, setMessage] = React.useState();

  useEffect(() => {
    console.log(code);
    switch (code) {
      case 200:
        setMessage(MESSAGE_PATCH);
        break;
      case 201:
        setMessage(MESSAGE_POST);
        break;
      case 404:
        setMessage(MESSAGE_404);
        break
      case 507:
        setMessage(MESSAGE_507);
        break;
      default:
        setMessage(MESSAGE_400);
        break;
    }
  });

  function createSnackbar(text, severity = "success") {
    return (
      <Snackbar open={open} autoHideDuration={6000} onClose={handleClose}>
        <Alert onClose={handleClose} severity={severity}>
          {text}
        </Alert>
      </Snackbar>
    );
  }

  const handleClick = () => {
    setOpen(true);
  };

  const handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }

    setOpen(false);
  };

  if (code < 400) {
    switch (code) {
      case 201:
        return createSnackbar(message);
      default:
        return createSnackbar(message);
    }
  } else {
    switch (code) {
      case 507:
        return createSnackbar(message, "error");
      default:
        return createSnackbar(message, "error");
    }
  }
}
