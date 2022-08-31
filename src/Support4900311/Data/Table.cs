using Base.ApServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Compori.Alphaplan.Plugin.Support.Data
{
    public sealed class Table : ITable
    {
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        // ReSharper disable once MemberCanBePrivate.Global
        private string Name { get; }

        /// <summary>
        /// Gets the primary key field.
        /// </summary>
        /// <value>The identifier field.</value>
        // ReSharper disable once MemberCanBePrivate.Global
        private string PrimaryKeyField { get; }

        /// <summary>
        /// Gets the identifier in primary key field.
        /// </summary>
        /// <value>The identifier.</value>
        private int Id => this.GetValue<int>(this.PrimaryKeyField);

        /// <summary>
        /// Gets or sets the current filter.
        /// </summary>
        /// <value>The current filter.</value>
        private List<string> Filter { get; set; }

        /// <summary>
        /// Gets the table factory.
        /// </summary>
        /// <value>The factory.</value>
        private TableFactory Factory { get; }

        /// <summary>
        /// Gets the writer.
        /// </summary>
        /// <value>The writer.</value>
        private IWriter Writer { get; set; }

        /// <summary>
        /// Gets the table handle.
        /// </summary>
        /// <value>The handle.</value>
        private IntPtr Handle { get; set; }

        /// <summary>
        /// Gets a list of constraint handles.
        /// </summary>
        /// <value>The constraints.</value>
        private List<IntPtr> Constraints { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Table" /> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="writer">The writer.</param>
        /// <param name="handle">The handle.</param>
        /// <param name="name">The name.</param>
        /// <param name="primaryKeyField">The primary key field.</param>
        public Table(TableFactory factory, IWriter writer, IntPtr handle, string name, string primaryKeyField)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(name, nameof(name));
            Guard.AssertArgumentIsNotNullOrWhiteSpace(primaryKeyField, nameof(primaryKeyField));

            this.Factory = factory;
            this.Writer = writer;
            this.Handle = handle;
            this.Constraints = new List<IntPtr>();
            this.Filter = new List<string>();
            this.Name = name;
            this.PrimaryKeyField = primaryKeyField;
        }

        /// <summary>
        /// Seeks to a record withe the specified identifier as primary key.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ITable.</returns>
        private ITable Seek(int id)
        {
            Guard.AssertArgumentIsInRange(id, nameof(id), v => v > 0);

            this.ClearConstraint();
            
            var filter = $"{this.PrimaryKeyField}={id}";
            var result = this.Writer.AddConstraintViaWhereString(this.Handle, filter);
            this.Constraints.Add(result);

            if (!this.Writer.RequerySingleRSTI(this.Handle))
            {
                throw new TableFilterException(this.Name,$"Could not seek id '{id}'.");
            }
            return this;
        }        
        
        /// <summary>
        /// Seeks to a record with the specified field value.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        private ITable Where(string field, string value)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(field, nameof(field));
            Guard.AssertArgumentIsNotNull(value, nameof(value));
            return this.Where($"{field}='{value.Replace("'", "''")}'");
        }

        /// <summary>
        /// Seeks to a record with the specified field value.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        private ITable Where(string field, int value)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(field, nameof(field));
            return this.Where($"{field}={value:D}");
        }

        /// <summary>
        /// Sets the filter with and to the current filter.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>ITable.</returns>
        private ITable AndWhere(string filter)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(filter, nameof(filter));
            return this.Where(filter, false);
        }

        /// <summary>
        /// Sets the filter with and to the current filter.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        private ITable AndWhere(string field, string value)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(field, nameof(field));
            Guard.AssertArgumentIsNotNull(value, nameof(value));
            return this.AndWhere($"{field}='{value.Replace("'", "''")}'");
        }

        /// <summary>
        /// Sets the filter with and to the current filter.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        private ITable AndWhere(string field, int value)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(field, nameof(field));
            return this.AndWhere($"{field}={value:D}");
        }

        /// <summary>
        /// Sets the filter.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="clear">if set to <c>true</c> [clear].</param>
        /// <returns>ITable.</returns>
        /// <exception cref="TableFilterException">Could not set filter.</exception>
        /// <exception cref="TableException">Could not set filter.</exception>
        private ITable Where(string filter, bool clear = true)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(filter, nameof(filter));

            if (clear)
            {
                // Entferne Einschränkungen
                this.ClearConstraint();
            }
            
            // setting Filter
            this.Filter.Add(filter);

            var result = this.Writer.AddConstraintViaWhereString(this.Handle, filter);
            this.Constraints.Add(result);

            if (!this.Writer.RequerySingleRSTI(this.Handle))
            {
                throw new TableFilterException(this.Name,"Could not set filter.");
            }
            return this;
        }

        /// <summary>
        /// Clears the constraint.
        /// </summary>
        private void ClearConstraint()
        {
            // Entferne Einschränkungen
            foreach (var constraint in this.Constraints)
            {
                this.Writer.ClearConstraint(constraint);
            }
            this.Filter.Clear();
            this.Constraints.Clear();
        }

        /// <summary>
        /// Clears the filter.
        /// </summary>
        /// <returns>ITable.</returns>
        /// <exception cref="TableException">Could not clear filter.</exception>
        private ITable Clear()
        {
            this.ClearConstraint();
            this.Writer.RequerySingleRSTI(this.Handle);
            //if (!this.Writer.RequerySingleRSTI(this.Handle))
            //{
            //    throw new TableException(this.Name,"Could not clear filter.");
            //}
            return this;
        }

        /// <summary>
        /// Creates a data record to table
        /// </summary>
        /// <param name="insertBefore">if set to <c>true</c> inserts data record before current position.</param>
        /// <returns>ITable.</returns>
        /// <exception cref="TableException">
        /// Could not insert a new data record in table '{this.Name}'.
        /// </exception>
        private ITable Create(bool insertBefore)
        {
            try
            {
                if (!this.Writer.AddNew(this.Handle, insertBefore))
                {
                    throw new TableException(this.Name,"Could not create a new data record.");
                }
                return this;
            }
            catch (Exception ex)
            {
                var alphaplanError = 0;
                var alphaplanErrorDescription = "";

                foreach (string key in ex.Data.Keys)
                {
                    switch (key)
                    {
                        // ReSharper disable once StringLiteralTypo
                        case "AP-Errornumber":
                            alphaplanError = ex.Data[key] as int? ?? 0;
                            break;
                        case "AP-Description":
                            alphaplanErrorDescription = ex.Data[key].ToString();
                            break;
                    }
                }

                if (alphaplanError > 0)
                {
                    throw new TableException(this.Name,alphaplanErrorDescription, ex);
                }

                throw;
            }
        }

        /// <summary>
        /// Updates the current data record.
        /// </summary>
        /// <returns>ITable.</returns>
        /// <exception cref="TableException"></exception>
        private ITable Update()
        {
            try
            {
                this.Writer.Update(this.Handle);
                //if (!this.Writer.Update(this.Handle))
                //{
                //    throw new TableException($"Could not update data record in table '{this.Name}'.");
                //}
                return this;
            }
            catch (Exception ex)
            {
                var alphaplanError = 0;
                var alphaplanErrorDescription = "";

                foreach (string key in ex.Data.Keys)
                {
                    switch (key)
                    {
                        // ReSharper disable once StringLiteralTypo
                        case "AP-Errornumber":
                            alphaplanError = ex.Data[key] as int? ?? 0;
                            break;
                        case "AP-Description":
                            alphaplanErrorDescription = ex.Data[key].ToString();
                            break;
                    }
                }

                if (alphaplanError > 0)
                {
                    throw new TableException(this.Name,alphaplanErrorDescription, ex);
                }

                throw;
            }
        }

        /// <summary>
        /// Deletes the current data record.
        /// </summary>
        /// <returns>ITable.</returns>
        /// <exception cref="TableException"></exception>
        private ITable Delete()
        {
            try
            {
                this.Writer.Delete(this.Handle);
                return this;
            }
            catch (Exception ex)
            {
                var alphaplanError = 0;
                var alphaplanErrorDescription = "";

                foreach (string key in ex.Data.Keys)
                {
                    switch (key)
                    {
                        // ReSharper disable once StringLiteralTypo
                        case "AP-Errornumber":
                            alphaplanError = ex.Data[key] as int? ?? 0;
                            break;
                        case "AP-Description":
                            alphaplanErrorDescription = ex.Data[key].ToString();
                            break;
                    }
                }

                if (alphaplanError > 0)
                {
                    throw new TableException(this.Name,alphaplanErrorDescription, ex);
                }

                throw;
            }
        }

        /// <summary>
        /// Gets the value of the field from current record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">The field.</param>
        /// <returns>T.</returns>
        /// <exception cref="TableException">
        /// The record pointer in invalid.
        /// or
        /// Data type '{typeof(T).FullName}' is not supported.
        /// </exception>
        private T GetValue<T>(string field)
        {
            if (!this.Writer.IsValid(this.Handle))
            {
                throw new TableException(this.Name,"The record pointer in invalid.");
            }

            object result;

            if (typeof(T) == typeof(byte))
            {
                result = (byte)this.Writer.GetIntegerValue(this.Handle, field);
            }
            else if (typeof(T) == typeof(short))
            {
                result = (short)this.Writer.GetIntegerValue(this.Handle, field);
            }
            else if (typeof(T) == typeof(int))
            {
                result = this.Writer.GetLongValue(this.Handle, field);
            }
            else if (typeof(T) == typeof(float))
            {
                result = (float)this.Writer.GetDoubleValue(this.Handle, field);
            }
            else if (typeof(T) == typeof(double))
            {
                result = this.Writer.GetDoubleValue(this.Handle, field);
            }
            else if (typeof(T) == typeof(DateTime))
            {
                result = this.Writer.GetDateTimeValue(this.Handle, field);
            }
            else if (typeof(T) == typeof(bool))
            {
                result = this.Writer.GetBoolValue(this.Handle, field);
            }
            else if (typeof(T) == typeof(string))
            {
                result = this.Writer.GetStringValue(this.Handle, field);
            }
            else if (typeof(T) == typeof(byte[]))
            {
                result = this.Writer.GetBinaryValue(this.Handle, field);
                if (result != null && result.GetType() == typeof(sbyte[]))
                {
                    result = Array.ConvertAll((sbyte[])result, v => unchecked((byte)v));
                }
            }
            else
            {
                throw new TableException(this.Name,$"Data type '{typeof(T).FullName}' is not supported.");

            }
            // convert
            if (result != null)
            {
                return (T)result;
            }

            return default;
        }

        /// <summary>
        /// Bytes to hexadecimal bit fiddle.
        /// 
        /// https://stackoverflow.com/questions/311165/how-do-you-convert-a-byte-array-to-a-hexadecimal-string-and-vice-versa/14333437#14333437
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        private static string ByteToHexBitFiddle(byte[] bytes)
        {
            var c = new char[bytes.Length * 2];
            for (var i = 0; i < bytes.Length; i++) {
                var b = bytes[i] >> 4;
                c[i * 2] = (char)(55 + b + (((b-10)>>31)&-7));
                b = bytes[i] & 0xF;
                c[i * 2 + 1] = (char)(55 + b + (((b-10)>>31)&-7));
            }
            return new string(c);
        }

        /// <summary>
        /// Sets the specified field in to record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        /// <exception cref="TableException">
        /// The record pointer in invalid.
        /// or
        /// A null value can not be converted into a int type for field '{field}'.
        /// or
        /// A null value can not be converted into a single type for field '{field}'.
        /// or
        /// A null value can not be converted into a double type for field '{field}'.
        /// or
        /// A null value can not be converted into a datetime type for field '{field}'.
        /// or
        /// A null value can not be converted into a boolean type for field '{field}'.
        /// or
        /// The value type {typeof(T).FullName} is not supported for field '{field}'.
        /// or
        /// </exception>
        private ITable Set<T>(string field, T value)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(field, nameof(field));

            try
            {

                if (!this.Writer.IsValid(this.Handle))
                {
                    throw new TableException(this.Name,"The record pointer in invalid.");
                }

                string stringValue;

                if (typeof(T) == typeof(int) || typeof(T) == typeof(byte) || typeof(T) == typeof(short))
                {
                    if (value == null)
                    {
                        throw new TableException(this.Name,$"A null value can not be converted into a int type for field '{field}'.");
                    }
                    stringValue = Convert.ToInt64(value).ToString("D");
                }
                else if (typeof(T) == typeof(float))
                {
                    if (value == null)
                    {
                        throw new TableException(this.Name,$"A null value can not be converted into a single type for field '{field}'.");
                    }
                    stringValue = Convert.ToSingle(value).ToString("G9");
                }
                else if (typeof(T) == typeof(double))
                {
                    if (value == null)
                    {
                        throw new TableException(this.Name,$"A null value can not be converted into a double type for field '{field}'.");
                    }
                    stringValue = Convert.ToDouble(value).ToString("G17");
                }
                else if (typeof(T) == typeof(DateTime))
                {
                    if (value == null)
                    {
                        throw new TableException(this.Name,$"A null value can not be converted into a datetime type for field '{field}'.");
                    }
                    stringValue = Convert.ToDateTime(value).ToString("dd.MM.yyyy HH:mm:ss");
                }
                else if (typeof(T) == typeof(bool))
                {
                    if (value == null)
                    {
                        throw new TableException(this.Name,$"A null value can not be converted into a boolean type for field '{field}'.");
                    }
                    stringValue = Convert.ToBoolean(value) ? "1" : "0";
                }
                else if (typeof(T) == typeof(string))
                {
                    stringValue = value as string;
                }
                else if (typeof(T) == typeof(byte[]))
                {
                    stringValue = value != null ? "0x" + ByteToHexBitFiddle(value as byte[]) : null;
                }
                else
                {
                    throw new TableException(this.Name,$"The value type {typeof(T).FullName} is not supported for field '{field}'.");
                }
                this.Writer.SetValue(this.Handle, field, stringValue);
                // var result = this.Writer.SetValue(this.Handle, ref field, ref stringValue);
                //if (!result)
                //{
                //    throw new TableException($"Could not set value for field '{field}'.");
                //}
                return this;
            }
            catch (Exception ex)
            {
                var alphaplanError = 0;
                var alphaplanErrorDescription = "";

                foreach (string key in ex.Data.Keys)
                {
                    switch (key)
                    {
                        // ReSharper disable once StringLiteralTypo
                        case "AP-Errornumber":
                            alphaplanError = ex.Data[key] as int? ?? 0;
                            break;
                        case "AP-Description":
                            alphaplanErrorDescription = ex.Data[key].ToString();
                            break;
                    }
                }

                if (alphaplanError > 0)
                {
                    throw new TableException(this.Name,alphaplanErrorDescription, ex);
                }

                throw;
            }
        }

        /// <summary>
        /// Moves to the first record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        private bool First()
        {
            return this.Writer.MoveFirst(this.Handle);
        }

        /// <summary>
        /// Moves to the last record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        private bool Last()
        {
            return this.Writer.MoveLast(this.Handle);
        }

        /// <summary>
        /// Moves to the next record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        private bool Next()
        {
            return this.Writer.MoveNext(this.Handle);
        }

        /// <summary>
        /// Moves to the previous record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        private bool Previous()
        {
            return this.Writer.MovePrevious(this.Handle);
        }

        #region ITable Implementation

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        string ITable.Name => this.Name;

        /// <summary>
        /// Gets the primary key field.
        /// </summary>
        /// <value>The identifier field.</value>
        string ITable.PrimaryKeyField => this.PrimaryKeyField;

        /// <summary>
        /// Gets the current filter.
        /// </summary>
        /// <value>The current filter.</value>
        string ITable.Filter => this.Filter.Count > 1
            ? "(" + string.Join(") AND (", this.Filter.ToArray()) + ")"
            : this.Filter.FirstOrDefault() ?? string.Empty;

        /// <summary>
        /// Gets the current filter.
        /// </summary>
        /// <value>The current filter.</value>
        string[] ITable.FilterList => this.Filter.ToArray();


        /// <summary>
        /// Gets the identifier in primary key field.
        /// </summary>
        /// <value>The identifier.</value>
        int ITable.Id => this.Id;

        /// <summary>
        /// Clears the filter.
        /// </summary>
        ITable ITable.Clear()
        {
            return this.Clear();
        }

        /// <summary>
        /// Seeks to a record with the specified field value.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        ITable ITable.Where(string field, string value)
        {
            return this.Where(field, value);
        }

        /// <summary>
        /// Seeks to a record withe the specified identifier as primary key.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ITable.</returns>
        ITable ITable.Seek(int id)
        {
            return this.Seek(id);
        }

        /// <summary>
        /// Sets the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns><c>true</c> if filter is applied successfully, <c>false</c> otherwise.</returns>
        ITable ITable.Where(string filter)
        {
            return this.Where(filter);
        }

        /// <summary>
        /// Seeks to a record with the specified field value.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        ITable ITable.Where(string field, int value)
        {
            return this.Where(field, value);
        }

        /// <summary>
        /// Sets the filter with and to the current filter.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>ITable.</returns>
        ITable ITable.AndWhere(string filter)
        {
            return this.AndWhere(filter);
        }

        /// <summary>
        /// Sets the filter with and to the current filter.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        ITable ITable.AndWhere(string field, string value)
        {
            return this.AndWhere(field, value);
        }

        /// <summary>
        /// Sets the filter with and to the current filter.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        ITable ITable.AndWhere(string field, int value)
        {
            return this.AndWhere(field, value);
        }


        /// <summary>
        /// Gets the value of the field from current record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">The field.</param>
        /// <returns>T.</returns>
        T ITable.Get<T>(string field)
        {
            return this.GetValue<T>(field);
        }

        /// <summary>
        /// Sets the specified field in to record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        ITable ITable.Set<T>(string field, T value)
        {
            return this.Set(field, value);
        }

        /// <summary>
        /// Create a new data record.
        /// </summary>
        /// <returns>ITable.</returns>
        ITable ITable.Create()
        {
            return this.Create(false);
        }

        /// <summary>
        /// Updates the current data record.
        /// </summary>
        /// <returns>ITable.</returns>
        ITable ITable.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Deletes the current data record.
        /// </summary>
        /// <returns>ITable.</returns>
        ITable ITable.Delete()
        {
            return this.Delete();
        }

        /// <summary>
        /// Moves to the first record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        bool ITable.First()
        {
            return this.First();
        }

        /// <summary>
        /// Moves to the last record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        bool ITable.Last()
        {
            return this.Last();
        }

        /// <summary>
        /// Moves to the next record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        bool ITable.Next()
        {
            return this.Next();
        }

        /// <summary>
        /// Moves to the previous record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        bool ITable.Previous()
        {
            return this.Previous();
        }

        #endregion

        #region IDisposable Support

        /// <summary>
        /// The disposed value
        /// </summary>
        private bool _disposedValue;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; 
        /// <c>false</c> to release only unmanaged resources.</param>
        // ReSharper disable once UnusedParameter.Local
#pragma warning disable IDE0060 // Nicht verwendete Parameter entfernen
        private void Dispose(bool disposing)
#pragma warning restore IDE0060 // Nicht verwendete Parameter entfernen
        {
            if (_disposedValue)
            {
                return;
            }

            if (this.Writer != null)
            {
                var closeWriter = this.Constraints.Count > 0;
                foreach (var constraint in this.Constraints)
                {
                    this.Writer.ClearConstraint(constraint);
                }
                if (closeWriter)
                {
                    this.Writer.Close();
                }
                this.Factory.Release(this.Writer);
                this.Handle = IntPtr.Zero;
                this.Writer = null;
            }
            _disposedValue = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
#pragma warning disable CA1063 // Implement IDisposable Correctly
        void IDisposable.Dispose()
#pragma warning restore CA1063 // Implement IDisposable Correctly
        {
            Dispose(true);
        }

        #endregion
    }
}
