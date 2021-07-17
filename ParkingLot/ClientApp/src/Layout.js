import React, { Component } from "react";

import NavBar from "../src/components/NavBar";

import CssBaseline from "@material-ui/core/CssBaseline";
import Typography from "@material-ui/core/Typography";
import Container from "@material-ui/core/Container";
import { sizing } from "@material-ui/system";
import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({}));

export const Layout = (props) => {
  const classes = useStyles();
  return (
    <div style={{ height: "100vh", margin: 0, padding: 0 }}>
      <NavBar></NavBar>
      <React.Fragment>
        <CssBaseline />
        <Container>{props.children}</Container>
      </React.Fragment>
    </div>
  );
};
