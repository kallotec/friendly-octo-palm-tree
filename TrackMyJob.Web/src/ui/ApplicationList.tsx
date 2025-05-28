import * as React from 'react';
import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { getMyApplications } from '@/data/api';

export async function ApplicationList() {

    const appList = await getMyApplications();

    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell align="left">Company</TableCell>
                        <TableCell align="right">Position</TableCell>
                        <TableCell align="right">Applied</TableCell>
                        <TableCell align="right">Actions</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {appList.map((item) => (
                        <TableRow
                            key={item.id}
                        >
                            <TableCell component="th" scope="row">
                                {item.companyName}
                            </TableCell>
                            <TableCell align="right">{item.positionTitle}</TableCell>
                            <TableCell align="right">{item.appliedAt}</TableCell>
                            <TableCell align="right">(actions)</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    )
}
