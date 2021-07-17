import React, { Component } from "react";

import PropTypes from "prop-types";
import { makeStyles } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import Typography from "@material-ui/core/Typography";
import Box from "@material-ui/core/Box";

import FormRegisterTicket from "../components/FormRegisterTicket";
import FormFinisherTicket from "../components/FormFinisherTicket";
import TablesFinancialGain from "../components/TablesReport";
import { sizing } from "@material-ui/system";
import { spacing } from "@material-ui/system";
import { shadows } from "@material-ui/system";

function TabPanel(props) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box p={3}>
          <Typography component={"span"} variant={"body2"}>
            {children}
          </Typography>
        </Box>
      )}
    </div>
  );
}

TabPanel.propTypes = {
  children: PropTypes.node,
  index: PropTypes.any.isRequired,
  value: PropTypes.any.isRequired,
};

function a11yProps(index) {
  return {
    id: `simple-tab-${index}`,
    "aria-controls": `simple-tabpanel-${index}`,
  };
}

const useStyles = makeStyles((theme) => ({
  tab: {
    marginTop: "10vh",
    backgroundColor: theme.palette.background.paper,
  },
}));

export default function Home() {
  const classes = useStyles();
  const [value, setValue] = React.useState(0);
  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <Box className={classes.tab} boxShadow={1}>
      <AppBar position="static" width={1} hight={1} p={5} m={1}>
        <Tabs
          centered
          value={value}
          onChange={handleChange}
          variant="fullWidth"
          width={1}
        >
          <Tab label="Gerar ticket" {...a11yProps(0)} />
          <Tab label="Finalizar Ticket" {...a11yProps(1)} />
          <Tab label="Relatório" {...a11yProps(2)} />
        </Tabs>
      </AppBar>
      <TabPanel value={value} index={0}>
        <FormRegisterTicket />
      </TabPanel>
      <TabPanel value={value} index={1}>
        <FormFinisherTicket />
      </TabPanel>
      <TabPanel value={value} index={2}>
        <TablesFinancialGain />
      </TabPanel>
    </Box>
  );
}
