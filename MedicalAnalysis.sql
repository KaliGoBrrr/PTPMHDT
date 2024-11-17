CREATE DATABASE MedicalAnalysis;
GO

USE MedicalAnalysis;
GO

-- Tạo bảng Users
CREATE TABLE Users (
    user_id INT PRIMARY KEY IDENTITY,
    username NVARCHAR(50) UNIQUE NOT NULL,
    password_hash NVARCHAR(255) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    role NVARCHAR(10) DEFAULT 'user' CHECK (role IN ('user', 'admin')),
    created_at DATETIME DEFAULT GETDATE()
);
GO

-- Tạo bảng AnalysisHistory
CREATE TABLE AnalysisHistory (
    analysis_id INT PRIMARY KEY IDENTITY,
    user_id INT FOREIGN KEY REFERENCES Users(user_id) ON DELETE CASCADE,
    analysis_date DATETIME DEFAULT GETDATE(),
    analysis_data NVARCHAR(MAX), -- Sử dụng NVARCHAR(MAX) thay vì JSON do SQL Server không hỗ trợ kiểu JSON trực tiếp
    result_summary NVARCHAR(MAX)
);
GO
CREATE PROCEDURE RegisterUser
    @p_username NVARCHAR(50),
    @p_password_hash NVARCHAR(255),
    @p_email NVARCHAR(100),
    @p_role NVARCHAR(10)
AS
BEGIN
    DECLARE @user_exists INT;

    -- Kiểm tra xem email đã tồn tại chưa
    SELECT @user_exists = COUNT(*) FROM Users WHERE email = @p_email;

    IF @user_exists = 0
    BEGIN
        INSERT INTO Users (username, password_hash, email, role)
        VALUES (@p_username, @p_password_hash, @p_email, @p_role);
    END
    ELSE
    BEGIN
        RAISERROR ('Email đã tồn tại.', 16, 1);
    END
END;
GO
CREATE PROCEDURE LoginUser
    @p_username NVARCHAR(50),
    @p_password_hash NVARCHAR(255),
    @p_role NVARCHAR(10) OUTPUT
AS
BEGIN
    DECLARE @auth_success INT;

    -- Kiểm tra username và mật khẩu
    SELECT @auth_success = COUNT(*)
    FROM Users
    WHERE username = @p_username AND password_hash = @p_password_hash;

    IF @auth_success = 1
    BEGIN
        -- Lấy vai trò của người dùng sau khi xác thực
        SELECT @p_role = role
        FROM Users
        WHERE username = @p_username;
    END
    ELSE
    BEGIN
        RAISERROR ('Đăng nhập thất bại.', 16, 1);
    END
END;
GO
INSERT INTO Users (username, password_hash, email, role)
VALUES 
('doctor_a', 'hashed_password_a', 'doctor_a@example.com', 'user'),
('admin_user', 'hashed_password_admin', 'admin@example.com', 'admin');
GO
