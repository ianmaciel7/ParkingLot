import React from "react";
import Paper from "@material-ui/core/Paper";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TablePagination from "@material-ui/core/TablePagination";
import TableRow from "@material-ui/core/TableRow";
import { useReportGet } from "../../hooks/useHome";
import TableFinancialGain from "../TableFinancialGain";
import TableToBePaid from "../TableToBePaid";
import Grid from "@material-ui/core/Grid";
import { Box } from "@material-ui/core";
import CircularProgress from "@material-ui/core/CircularProgress";

export default function TablesReport() {
  const { report, loading, error } = useReportGet();

  console.log(report);

  if (loading === false && error === false) {
    return (
      <Grid container spacing={5}>
        <Grid item xs={12} md={6}>
          <Box boxShadow={1}>
            <TableFinancialGain rows={report.listPaid} />
          </Box>
        </Grid>

        <Grid item xs={12} md={6}>
          <Box boxShadow={1}>
            <TableToBePaid rows={report.listUnpaid} />
          </Box>
        </Grid>
      </Grid>
    );
  } else if (loading === true && error === false) {
    return <CircularProgress />;
  } else {
    return <div></div>;
  }
}
